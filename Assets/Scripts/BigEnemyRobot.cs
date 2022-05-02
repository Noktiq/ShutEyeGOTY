using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BigEnemyRobot : MonoBehaviour
{
    public int BigmaxHealth = 8000;
    public int BigcurrentHealth;
    public Transform player;

    // public Transform attackPoint;
    // public float attackRange = 0.5f;
    // public int attackDamage = 20;
    
    public LayerMask playerLayers;
    Animator EnemyAnimator;
    public bool enemyKnocked;
    AudioSource PunchSound;
    public victorEnemyHealthBar healthbar;
    

    // Start is called before the first frame update
    void Start()
    {
        BigcurrentHealth = BigmaxHealth;
        EnemyAnimator = gameObject.GetComponent<Animator>();
        enemyKnocked = false;
        PunchSound =GetComponent<AudioSource>();
        healthbar.SetHealth(BigmaxHealth);
    }

    void Update()
    {
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     // Attack();
        // }
        // // if(enemyKnocked == false)
        // // {
        // // transform.LookAt(player);
        // // }

        if(BigcurrentHealth <=0)
        {
            PlayerPrefs.SetInt("LevelCounter", (PlayerPrefs.GetInt("LevelCounter") + 1));
           SceneManager.LoadScene("HubComeback");
        }
        
    }

    public void BigTakeDamage(int damage)
    {
        
        BigcurrentHealth -= damage;
        healthbar.SetHealth(BigcurrentHealth);
        // PunchSound.Play();
        StartCoroutine(WaitBeforeHurtAnim());
        // EnemyAnimator.SetBool("EnemyHurt", true);
       

        if(BigcurrentHealth <= 0)
        {
            BigDie();
        }
        
    }

     IEnumerator WaitBeforeHurtAnim()
    {
        
        //Debug.Log("THATSHITHURTED");
        EnemyAnimator.SetBool("EnemyHurt", true);
        yield return new WaitForSeconds(.3f);
        EnemyAnimator.SetBool("EnemyHurt", false);
    }

    void Attack()
    {
        //play animation

        //detect enemies
    //    Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);
    //     // Damage
    //     foreach(Collider player in hitPlayer)
    //     {
    //         player.GetComponent<PlayerCombat>().PlayerDamage(attackDamage);
    //         Debug.Log("Player damage");
            
            
    //     }
    }

    
    void BigDie()
    {
        Debug.Log("Enemy died");
        EnemyAnimator.SetBool("knockout", true);
        // Destroy(gameObject);
        //SceneManager.LoadScene("HubReturn");
        enemyKnocked = true;
    }

    // void OnDrawGizmosSelected()
    // {
    //     if (attackPoint == null)
    //         return;

    //     Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    // }
}
