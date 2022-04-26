using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMiniFridge : MonoBehaviour
{
    Animator FridgeAnimator;
    public float pickUpRange;
    public Transform player;
    AudioSource f_AudioSource;
    public bool fridgeOpened;
    public bool fridgeClosed;
    public GameObject InteractUI;
    // Start is called before the first frame update
    void Start()
    {
        FridgeAnimator = gameObject.GetComponent<Animator>();
        fridgeOpened = false;
        fridgeClosed = true;
    }

    public void OnTriggerEnter()
    {
        if(fridgeOpened == false)
        {
        InteractUI.SetActive(true);
        }
    }

    public void OnTriggerExit()
    {
        InteractUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E)))
         {
            //  FridgeAnimator.SetBool("fridgeOpened", true);
            //  FridgeAnimator.SetBool("fridgeClosed", false);
             fridgeOpened = true;
             fridgeClosed = false;
            StartCoroutine(waitbeforeclose());
            
         }


         if(fridgeOpened == true)
         {
             InteractUI.SetActive(false);
         }
           
           
            //curtainOpened = true;

            
            //Debug.Log("WORKING");
         

         IEnumerator waitbeforeclose()
         {
             FridgeAnimator.SetBool("fridgeOpened", true);
             yield return new WaitForSeconds(7);
             FridgeAnimator.SetBool("fridgeOpened", false);
             fridgeClosed = true;
             fridgeOpened = false;
         }

        //  if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E) && fridgeOpened == true ))
        //  {
        //      FridgeAnimator.SetBool("fridgeClosed", true);
        //      FridgeAnimator.SetBool("fridgeOpened", false);
        //      fridgeOpened = false;
           
           
        //     //curtainOpened = true;

            
        //     Debug.Log("WORKING");
        //  }
    }
}
