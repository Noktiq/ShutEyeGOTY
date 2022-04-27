using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmathTrigger : MonoBehaviour
{

    public float pickUpRange;
    public Transform player;
    public Dialogue dialogue;
    public GameObject BlueprintChatUI;
    public dialogueManager script;
    public GameObject talking;
    public GameObject InteractUI;
    public bool Interactedwith = false;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E) ))
         {
             
             Interactedwith = true;
            TriggerDialogue();
            InteractUI.SetActive(false);
            
            BlueprintChatUI.SetActive(true);
            // ThirdpersonCam.GetComponent<CinemachineFreeLook>().enabled = false;
            
            //Debug.Log("WORKING");
            // StartCoroutine(waitTalk1());

            
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
