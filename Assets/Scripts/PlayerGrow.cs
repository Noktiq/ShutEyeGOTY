using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrow : MonoBehaviour
{
    public bool isBig;
    
    // Start is called before the first frame update
    void Start()
    {
        isBig = false;
    }

    // Update is called once per frame
    void Update()
    {

     if (Input.GetButtonDown("Fire3")) 
     {
         transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
         isBig = true;
     } 

     if (Input.GetButtonDown("Shrink"))
     {
         transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
         isBig = false;
     }

    }
}
