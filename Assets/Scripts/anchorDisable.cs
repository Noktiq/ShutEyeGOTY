using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorDisable : MonoBehaviour
{

    public mouseTarget script;
    public GameObject anchor;

    // Start is called before the first frame update
    void Start()
    {
        anchor.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        //PROBLEM WITH DETECTING BOOL WHEN PLAYER CUTS, FOR NOW ITS JUST ON CLICK
        // if(Input.GetButtonDown("Fire1"))
        // {
            
        //     anchor.SetActive(false);
        //     Debug.Log("should cut now");
        // }

        //  void OnMouseEnter()
        // {
        //     if(Input.GetButtonDown("Fire1"))
        //     {
        //         anchor.SetActive(false);
        //         Debug.Log("should cut now");
        //     }
        // }
        // if(script.playerCut == true)
        // {
        //     anchor.SetActive(false);
        // }
    }

    

    // private void disableAnchor()
    // {
    //     if(script.playerCut == true)
    //     {
    //         anchor.SetActive(false);
    //     }
    // }
}
