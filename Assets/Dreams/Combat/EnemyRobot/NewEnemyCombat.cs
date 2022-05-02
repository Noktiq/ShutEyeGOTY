using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyCombat : MonoBehaviour
{


    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    //public int damageDealt = 1;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public Collider[] attackHitbox;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public BigEnemyRobot script;
    //public int damageDealt = 0;

    public int damageDealt = 20;
    public bool enemyAttackedNowWait;
    public Animator EnemyAnimator;
    public stayInside script2;
    public AudioSource AudioSource;

    void Start()
    {
        EnemyAnimator = gameObject.GetComponent<Animator>();
        AudioSource = gameObject.GetComponent<AudioSource>();
    }
    
    private void Awake()
    {
        player = GameObject.Find("VictorRobotIdleAnim").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange && script.enemyKnocked == false && script2.playerInside == true) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && script.enemyKnocked == false) AttackPlayer(attackHitbox[0]);
    }

    private void Patroling()
    {
        if(script.enemyKnocked == false)
        {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        // if(script.enemyKnocked == false)
        // {
        agent.SetDestination(player.position);

        

        //  } 
  }

    private void AttackPlayer(Collider col)
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here

            Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Player"));

            //End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            Debug.Log("Oochie Ouchie");
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
        // VictorAnimator.SetBool("Punched", true);
        
        
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }





    void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag =="Player")
        {
            if(enemyAttackedNowWait == false)
            {
                if(script.enemyKnocked == false)
                {
            StartCoroutine(waitToHurt());
                }
            }
        }
    }

    IEnumerator waitToHurt()
    {
        if(script.enemyKnocked == false)
        {
            
        FindObjectOfType<PlayerCombat1>().EnemyRobotHurtPlayer(damageDealt);
        
        enemyAttackedNowWait = true;
        StartCoroutine(waitToHurtAnim());
        yield return new WaitForSeconds(2);
        enemyAttackedNowWait = false;
        }
    }

    IEnumerator waitToHurtAnim()
    {
        EnemyAnimator.SetBool("EnemyPunch", true);
        yield return new WaitForSeconds(.4f);
        EnemyAnimator.SetBool("EnemyPunch", false);

    }

   



}