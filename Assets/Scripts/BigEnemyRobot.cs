using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BigEnemyRobot : MonoBehaviour
{
    public int BigmaxHealth = 50000;
    public int BigcurrentHealth;
    public Transform player;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    
    public LayerMask playerLayers;
    

    // Start is called before the first frame update
    void Start()
    {
        BigcurrentHealth = BigmaxHealth;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        transform.LookAt(player);
    }

    public void BigTakeDamage(int damage)
    {
        
        BigcurrentHealth -= damage;
       

        if(BigcurrentHealth <= 0)
        {
            BigDie();
        }
        
    }

    void Attack()
    {
        //play animation

        //detect enemies
       Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);
        // Damage
        foreach(Collider player in hitPlayer)
        {
            player.GetComponent<PlayerCombat>().PlayerDamage(attackDamage);
            Debug.Log("Player damage");
            
        }
    }

    
    void BigDie()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
        SceneManager.LoadScene("WinScreen");
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
