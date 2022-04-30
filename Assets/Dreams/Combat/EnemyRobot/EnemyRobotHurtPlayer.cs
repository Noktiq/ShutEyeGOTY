using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobotHurtPlayer : MonoBehaviour
{
    public int damageDealt = 253;
    public float pickUpRange;
    public Transform player;
    public 
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(FindObjectsOfType<PlayerCombat>().EnemyRobotHurtPlayer.Length);
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

     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerCombat>().EnemyRobotHurtPlayer(damageDealt);
            //Debug.Log("Oochie Ouchie");
        }
    }


     
         
}
