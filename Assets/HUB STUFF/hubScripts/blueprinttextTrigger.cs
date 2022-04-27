using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class blueprinttextTrigger : MonoBehaviour
{

    public float pickUpRange;
    public Transform player;
    public Dialogue dialogue;
    public GameObject BlueprintChatUI;
    public dialogueManager script;
    AudioSource audioSource;
    public GameObject talking;
    public bool convoStarted;
    public GameObject InteractUI;

    
    // Start is called before the first frame update
    void Start()
    {
        // BlueprintChatUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        talking.SetActive(false);
        convoStarted = false;
    }

    public void OnTriggerEnter()
    {
        InteractUI.SetActive(true);
    }

    public void OnTriggerExit()
    {
        InteractUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E) ))
         {
             convoStarted= true;
             InteractUI.SetActive(false);
             
            TriggerDialogue();
            
            BlueprintChatUI.SetActive(true);
            // ThirdpersonCam.GetComponent<CinemachineFreeLook>().enabled = false;
            
            //Debug.Log("WORKING");
            // StartCoroutine(waitTalk1());

            
         }

        //  if(Input.GetButtonDown("Jump"))
        //     {
        //     StartCoroutine(waitTalk2());
        //     }

         

        //  if(script.convoTalking == true)
        //  {
        //      audioSource.mute = !audioSource.mute;
        //      talking.SetActive(true);
        //  }
         
        //  if(script.convoTalking == false)
        //  {
        //      StopAllCoroutines();
        //  }
    }

    public void Nowtalking()
    {
        StartCoroutine(waitTalk1());
    }

    public IEnumerator waitTalk1()
    {
        talking.SetActive(true);
        yield return new WaitForSeconds(.7f);
        talking.SetActive(false);
    }

    public IEnumerator waitTalk2()
    {
        talking.SetActive(true);
        yield return new WaitForSeconds(1f);
        talking.SetActive(false);
    }
    


    public void TriggerDialogue()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }

}
