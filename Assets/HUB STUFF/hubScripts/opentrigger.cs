using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opentrigger : MonoBehaviour
{
    Animator curtainAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        curtainAnimator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            curtainAnimator.SetBool("buttonPressed", true);
        }
    }
}
