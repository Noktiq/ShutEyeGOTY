using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booSoundTrigger : MonoBehaviour
{
    public ThirdPersonMovement script;
    AudioSource BooTrigger;
    // Start is called before the first frame update
    void Start()
    {
        BooTrigger= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (script.BooActivate == true)
        // {
        //     BooTrigger.Play();
        // }
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !BooTrigger.isPlaying)
        {
           BooTrigger.Play();
        }
    }
}
