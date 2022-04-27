using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobotHurtPlayer : MonoBehaviour
{
    public int damageDealt = 1;
    public float pickUpRange;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 distanceToPlayer = player.position - transform.position;
        // if(distanceToPlayer.magnitude >= pickUpRange)
        //  {
            
        //      FindObjectOfType<PlayerCombat>().EnemyRobotHurtPlayer(damageDealt);
        //  }

    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerCombat>().EnemyRobotHurtPlayer(damageDealt);
        }
    }


     
         
}
