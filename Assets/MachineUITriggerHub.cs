using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineUITriggerHub : MonoBehaviour
{
    public GameObject InteractUI;
    public Transform player;
     public float pickUpRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E)))
         {
            //  FridgeAnimator.SetBool("fridgeOpened", true);
            //  FridgeAnimator.SetBool("fridgeClosed", false);
             InteractUI.SetActive(false);
             Debug.Log("TestingUI");
            
         }
    }

    public void OnTriggerEnter()
    {
        
        
        InteractUI.SetActive(true);
        
    }

    public void OnTriggerExit()
    {
        InteractUI.SetActive(false);
    }
}
