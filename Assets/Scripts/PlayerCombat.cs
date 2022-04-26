using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public PlayerGrow script;
    public BigEnemyRobot script2;
    public GameObject BigGuy;

    public int maxHealth;
    public int currentHealth;
    public Collider[] attackHitbox;

    Animator VictorAnimator;
    AudioSource BellSound;
    // AudioSource PunchSound;



    void Start()
    {
        script.isBig = false;
        
        VictorAnimator = gameObject.GetComponent<Animator>();
        // PunchSound =GetComponent<AudioSource>();
        BellSound =GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Fire1") && script.isBig == true)
        {
            AttackBig(attackHitbox[0]);
            // PunchSound.Play();
            // VictorAnimator.SetBool("Punched", true);
            StartCoroutine(WaitBeforeHit());

        }
        if(script2.enemyKnocked == true)
        {
            BellSound.Play();
        }

        

        if (Input.GetButtonDown("Fire1") && script.isBig == false)
        {
            AttackSmall(attackHitbox[1]);
        }

        if(script.isBig == true)
        {
            attackDamage = 10000;
            maxHealth = 55000;
            currentHealth = maxHealth;
        }
        else
        {
        attackDamage = 20;
        maxHealth = 100;
        currentHealth = maxHealth;
        }
    }

    IEnumerator WaitBeforeHit()
    {
        
        Debug.Log("FIRED");
        VictorAnimator.SetBool("Punched", true);
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
            c.GetComponent<BigEnemyRobot>().BigTakeDamage(attackDamage);
            Debug.Log("taking damage");
            
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
            Debug.Log("taking damage");
            
        }
    }

    public void EnemyRobotHurtPlayer(int damageDealt)
    {
        currentHealth -= damageDealt;
    }


    
    
}
