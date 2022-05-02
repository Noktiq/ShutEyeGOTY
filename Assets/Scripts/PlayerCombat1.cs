using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat1 : MonoBehaviour
{
    
    public LayerMask enemyLayers;
    public int attackDamage = 100000;
    public PlayerGrow script;
    public BigEnemyRobot script2;
    public GameObject BigGuy;
    

    public int maxHealth;
    public int currentHealth;
    public Collider[] attackHitbox;

    Animator VictorAnimator;
    AudioSource BellSound;
    public bool enemyAttackedNowWait;
    public bool playerBlocking;
    public cameraShake1 CameraShake1;
    public VictorHealthBar healthbar;
    public bool playerAttackedNowWait;
    public bool playerisDead;
    // AudioSource PunchSound;



    void Start()
    {
        script.isBig = false;
        
        VictorAnimator = gameObject.GetComponent<Animator>();
        // PunchSound =GetComponent<AudioSource>();
        BellSound =GetComponent<AudioSource>();
        maxHealth = 200;
        currentHealth = 200;
        playerBlocking=false;
        healthbar.SetHealth(maxHealth);
        playerAttackedNowWait=false;
        
    }
    // Update is called once per frame
    void Update()
    {   

        if (Input.GetButtonDown("Jump"))
        {

            if(playerBlocking == true)
            {
            playerBlocking = false;
            Debug.Log("PlayerBlocking");
            VictorAnimator.SetBool("PlayerBlocked", false);
            }
            else
            {
            playerBlocking = true;
            Debug.Log("PlayerSTOPBLOCKING");
            VictorAnimator.SetBool("PlayerBlocked", true);
            }

        }

        if(currentHealth <= 0)
        {
            playerisDead = true;
            StartCoroutine(waitToDie());
        }

        IEnumerator waitToDie()
        {
            
            {
                VictorAnimator.SetBool("PlayerDead", true);
                yield return new WaitForSeconds(4);
                SceneManager.LoadScene("CombatPart2");
            }
        }

        // else
        // playerBlocking = false;
        // VictorAnimator.SetBool("PlayerBlocked", false);


        if (Input.GetButtonDown("Fire1") )
        {
            if(playerBlocking == false);
            {
            StartCoroutine(CameraShake1.Shake(1f,.3f));
            //AttackBig(attackHitbox[0]);
            // PunchSound.Play();
            // VictorAnimator.SetBool("Punched", true);
            StartCoroutine(StopAttackSpam());
            StartCoroutine(WaitBeforeHit());
            
            }
        }
        if(script2.enemyKnocked == true)
        {
            BellSound.Play();
        }

        

        // if (Input.GetButtonDown("Fire1") && script.isBig == false)
        // {
        //     if(playerBlocking == false)
        //     {
        //     AttackSmall(attackHitbox[1]);
        //     }
        // }

        // if(script.isBig == true)
        // {
        //     attackDamage = 10000;
        //     currentHealth = 55000;
        //     //currentHealth = maxHealth;
        // }
        // else
        // {
        // attackDamage = 20;
        // //maxHealth = 100;
        
        // }
    }

    
    IEnumerator WaitBeforeHit()
    {
        
        //Debug.Log("FIRED");
        VictorAnimator.SetBool("Punched", true);
         //AttackBig(attackHitbox[0]);
         Debug.Log("I attacked!");
        yield return new WaitForSeconds(.1f);
        VictorAnimator.SetBool("Punched", false);
        
    }

    

    void AttackBig(Collider col)
    {
        //play animation

        //detect enemies
       Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Enemies"));
        // Damage
        foreach(Collider c in cols)
        {
            if(playerBlocking == false)
            {
            c.GetComponent<BigEnemyRobot>().BigTakeDamage(attackDamage);
            Debug.Log("taking damage");
            }
        }
    }

    void AttackSmall(Collider col)
    {
        //play animation

        //detect enemies
      Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Enemies"));
        // Damage
        foreach(Collider c in cols)
        {
            c.GetComponent<EnemyRobot>().TakeDamage(attackDamage);
            //Debug.Log("taking damage");
            
        }
    }

    public void EnemyRobotHurtPlayer(int damageDealt)
    {
        if(playerBlocking == false)
        {
        currentHealth -= damageDealt;
        healthbar.SetHealth(currentHealth);
        StartCoroutine(waitToHurtAnim());
        StartCoroutine(CameraShake1.Shake(1f, .3f));
        }

        if(playerBlocking == true)
        {
        StartCoroutine(waittoBlockHurtAnim());
        }

    }


    IEnumerator waittoBlockHurtAnim()
    {
        VictorAnimator.SetBool("PlayerHurtWhenBlock", true);
         yield return new WaitForSeconds(.2f);
         VictorAnimator.SetBool("PlayerHurtWhenBlock", false);
    }

    IEnumerator waitToHurtAnim()
    {
         VictorAnimator.SetBool("PlayerHurted", true);
         yield return new WaitForSeconds(.4f);
         VictorAnimator.SetBool("PlayerHurted", false);
         
    }

    IEnumerator StopAttackSpam()
    {
         if(playerAttackedNowWait == false)
         {
         AttackBig(attackHitbox[0]);
         playerAttackedNowWait = true;
         yield return new WaitForSeconds(.4f);
         playerAttackedNowWait = false;
         }
        //  yield return new WaitForSeconds(.4f);
        //  playerAttackedNowWait = false);
    }
    // }
    //     IEnumerator StopAttackSpam()
    // {
    //      playerAttackedNowWait = true);
    //      yield return new WaitForSeconds(.12f);
    //      playerAttackedNowWait = false);
         
    // }
    

    // // private void OnTriggerEnter(Collider other)
    // // {
    // //     if(other.gameObject.tag == "Enemy")
    // //     {
    // //         currentHealth-=20;
    // //         Debug.Log("CollisionEnemy");
    // //     }
       
    // // }

    // void OnTriggerStay(Collider other)
    // {

    //     if(other.gameObject.tag =="Enemy")
    //     {
    //         if(enemyAttackedNowWait == false)
    //         {
    //         StartCoroutine(waitToHurt());
    //         }
    //     }
    // }

    // IEnumerator waitToHurt()
    // {
    //     currentHealth-=20;
    //     enemyAttackedNowWait = true;
    //     StartCoroutine(waitToHurtAnim());
    //     yield return new WaitForSeconds(2);
    //     enemyAttackedNowWait = false;

    // }

    // IEnumerator waitToHurtAnim()
    // {
    //      VictorAnimator.SetBool("PlayerHurted", true);
    //      yield return new WaitForSeconds(.4f);
    //      VictorAnimator.SetBool("PlayerHurted", false);
         
    // }


    
    
}