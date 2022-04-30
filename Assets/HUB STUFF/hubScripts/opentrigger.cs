using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opentrigger : MonoBehaviour
{
    Animator curtainAnimator;
    public float pickUpRange;
    public Transform player;
    AudioSource m_MyAudioSource;
    bool curtainOpened;
    public GameObject InteractUI;





    public void OnTriggerEnter()
    {
        if(curtainOpened == false)
        {
        InteractUI.SetActive(true);
        }
    }

    public void OnTriggerExit()
    {
        InteractUI.SetActive(false);
    }

    
    

    // Start is called before the first frame update
    void Start()
    {
        curtainAnimator = gameObject.GetComponent<Animator>();
       m_MyAudioSource = GetComponent<AudioSource>();
       curtainOpened = false;
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E) && curtainOpened == false))
         {
             curtainAnimator.SetBool("buttonPressed", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            m_MyAudioSource.Play();
            curtainOpened = true;
            
            Debug.Log("WORKING");

         }

         if(curtainOpened == true)
         {
             InteractUI.SetActive(false);
         }
    }
    

    
}
