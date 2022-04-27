using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CelWakeUp : MonoBehaviour
{

    Animator CelAnimator;
    public float pickUpRange;
    public Transform player;
    public Dialogue dialogue;
    public GameObject CelChatUI;
    public dialogueManager script;
    // public GameObject ThirdpersonCam;
    
    // Start is called before the first frame update
    void Start()
    {

        CelAnimator = gameObject.GetComponent<Animator>();
        CelChatUI.SetActive(false);
        
    //AudioSource m_MyAudioSource;
    //bool curtainOpened;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E) ))
         {
             CelAnimator.SetBool("CelWake", true);
             CelAnimator.SetBool("backSleep",false);
            // gameObject.GetComponent<BoxCollider>().enabled = false;
            // m_MyAudioSource.Play();
            // curtainOpened = true;
            TriggerDialogue();
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
            CelChatUI.SetActive(true);
            // ThirdpersonCam.GetComponent<CinemachineFreeLook>().enabled = false;
            
            Debug.Log("WORKING");

         }

          if(script.CelConvoEnded == true)
            {
                CelChatUI.SetActive(false);
            }


            if(distanceToPlayer.magnitude >= pickUpRange )
           {
             CelAnimator.SetBool("CelWake", false);
             CelAnimator.SetBool("backSleep", true);
            
           }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }


    // void OnTriggerExit(Collider other)
    // {
    //     if(other.tag == "Player")
    //     {
    //     // Destroy everything that leaves the trigger
    //     CelAnimator.SetBool("BackSleep", true);
    //     CelAnimator.SetBool("CelWake", false);
    //     }
    // }
}
