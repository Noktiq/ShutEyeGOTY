using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStepSound : MonoBehaviour
{
    private AudioSource audioSource;
    public ThirdPersonMovement2 script;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

   

    void FixedUpdate()
    {


                if  (!audioSource.isPlaying)
            {
 
                if (audioSource.isPlaying == false) 
                {
 
                    if (script.isWalking == true && script.isGrounded ==true ) 
                    {
                        Debug.Log("ON");
 
                        audioSource.Play ();
                    } 
                    
                }
            }
                
                    if (script.isWalking == false )
                    {

                        // Debug.Log("OFF");
                        audioSource.Stop();
                    }

                    if (script.isGrounded == false)
                    {
                        audioSource.Stop();
                    }
    }
}
