using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageDealt = 1;
    Animator EnemyAnimator;
    public float pickUpRange;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
       EnemyAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(distanceToPlayer.magnitude >= pickUpRange)
         {
            EnemyAnimator.SetBool("enemyAttacked", false);

         }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<ThirdPersonMovement>().HurtPlayer(damageDealt);
            EnemyAnimator.SetBool("enemyAttacked", true);
        }
        // else
        // {
        //     EnemyAnimator.SetBool("enemyAttacked", false);
        // }
    }


}