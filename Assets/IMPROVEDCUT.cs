using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMPROVEDCUT : MonoBehaviour
{

    public GameObject ROPE;
    
    public bool playerCut;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(playerCut == true)
     {

     }   
    }

    void OnMouseDown()
    {
    ROPE.SetActive(false);
    playerCut = true;
    }
}
