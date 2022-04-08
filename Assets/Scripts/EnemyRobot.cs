using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRobot : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    
    void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}
