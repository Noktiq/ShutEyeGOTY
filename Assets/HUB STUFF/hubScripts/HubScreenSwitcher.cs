using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubScreenSwitcher : MonoBehaviour
{
    private Animator animator;
    public GameObject PcCanvas;
    public GameObject player;
    public PCMachineUI script;
    public PCMachineUI1 script2;
    public PCMachineUI2 script3;
    public float pickUpRange;
    public Transform playerTrans;

    void Update ()
    {
        if(script.PortalActivated == true)
        {
        animator.Play("overworldcam");
        }

        if(script2.PortalActivated1 == true)
        {
        animator.Play("overworldcam");
        }

        if(script3.PortalActivated2 == true)
        {
            animator.Play("overworldcam");
        }

        Vector3 distanceToPlayer = playerTrans.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E)))
         {
             animator.Play("machinecam");
              if (script.PortalActivated == false && script2.PortalActivated1 == false && script3.PortalActivated2 == false)
            {
            StartCoroutine(WaitBeforeShow());
            }
         }
    }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        Cursor.visible = false;
        PcCanvas.SetActive(false);
        
    }
 

    //  void OnTriggerEnter(Collider other) 
    //  {
    //      if (other.tag == "Player") 
    //      {
             
    //         //  animator.Play("machinecam");
    //         // // Cursor.visible = true;
    //         // //Cursor.lockState = CursorLockMode.None;
            
    //         // Debug.Log("SWITCH");
            
    //         if (script.PortalActivated == false && script2.PortalActivated1 == false && script3.PortalActivated2 == false)
    //         {
    //         StartCoroutine(WaitBeforeShow());
    //         }
    //      }
        
    //  }

      private IEnumerator WaitBeforeShow()
      {
           yield return new WaitForSeconds(.6f);
          Time.timeScale = 0f;
           Cursor.visible = true;
          Cursor.lockState = CursorLockMode.None;
          player.SetActive(false);
          PcCanvas.SetActive(true);

      }

    //  void OnTriggerExit(Collider other) 
    // {
    // //      if(other.tag == "Player")
    // //      {
         
    // //          animator.Play("overworldcam");
    // //          Cursor.visible = false;
    // //          Cursor.lockState = CursorLockMode.Locked;
    // //          PcCanvas.SetActive(false);
    // //      }

    //     //  Debug.Log("ReverseSwitch");
         
    //  }
}
