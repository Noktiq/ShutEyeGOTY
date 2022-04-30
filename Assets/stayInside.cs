using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayInside : MonoBehaviour
{
    public bool playerInside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInside = true;
        }
        

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInside = false;
        }
    }
}
