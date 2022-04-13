using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public PlayerGrow script;
    public GameObject BigGuy;

    public int health;
    public int currentHealth;
    public Collider[] attackHitbox;


    void Start()
    {
        script.isBig = false;
        currentHealth = health;
    }
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Fire1") && script.isBig == true)
        {
            AttackBig(attackHitbox[0]);
        }

        if (Input.GetButtonDown("Fire1") && script.isBig == false)
        {
            AttackSmall(attackHitbox[1]);
        }

        if(script.isBig == true)
        {
            attackDamage = 10000;
            currentHealth = 55000;
        }
        else
        {
        attackDamage = 20;
        currentHealth = 100;
        }
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

    public void PlayerDamage(int damage)
    {
        currentHealth -= damage;
    }

    
}
