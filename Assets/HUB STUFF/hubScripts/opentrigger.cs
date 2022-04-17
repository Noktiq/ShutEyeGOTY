using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opentrigger : MonoBehaviour
{
    Animator curtainAnimator;
    public float pickUpRange;
    public Transform player;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        curtainAnimator = gameObject.GetComponent<Animator>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E)))
         {
             curtainAnimator.SetBool("buttonPressed", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;

         }
    }
    

    
}
