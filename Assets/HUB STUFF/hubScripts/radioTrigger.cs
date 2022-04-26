using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioTrigger : MonoBehaviour
{

    public float pickUpRange;
    public Transform player;
    AudioSource m_MyAudioSource;
    bool radioPressed;
    public GameObject InteractUI;

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
       radioPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
         if(distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E) && radioPressed == false))
         {
             
            
            m_MyAudioSource.Play();
            radioPressed = true;
            
            Debug.Log("WORKING");

         }

         if(radioPressed == true)
         {
             InteractUI.SetActive(false);
         }
    }

     public void OnTriggerEnter()
    {
        if(radioPressed == false)
        {
        InteractUI.SetActive(true);
        }
    }

    public void OnTriggerExit()
    {
        InteractUI.SetActive(false);
    }
}
