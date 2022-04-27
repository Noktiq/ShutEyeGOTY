using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundTrigger : MonoBehaviour
{
    AudioSource jumpTrigger;
    public ThirdPersonMovement script;
    
    
    // Start is called before the first frame update
    void Start()
    {
        jumpTrigger= GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (script.isGrounded == true)
        // {
        //     audioSource.Stop();
        // }

        if (Input.GetButtonDown("Jump") && script.isGrounded == true)
        {
            if(!jumpTrigger.isPlaying)
            {
           jumpTrigger.Play();
           //Debug.Log("audioshouldplay");
            
            }
        }     
    }
}
