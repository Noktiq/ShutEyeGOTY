using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherMouseTarget : MonoBehaviour
{
    
    // public mouseTarget script;
    public GameObject anchor2;
    public bool isonobject;
    public GameObject rope1;
    
    // Start is called before the first frame update
    // mouseTarget script = GameObject.Find("ObjectName");
    void Start()
    {
        // Rrenderer = GetComponent<Renderer>();
        // anchor2.SetActive(true);
        // onobject=false;
        // playerCut = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        ////UNCOMMENT BELOW IF YOU WANT ON CLICK CUTTING
        if(isonobject==true && Input.GetButtonDown("Fire1"))
        {
            // playerCut=true;
            // Destroy(gameObject);
            
            anchor2.SetActive(false);
            rope1.SetActive(false);
            
        }
        // else
        // {
        //     playerCut=false;
        // }
    }

    

    private void OnMouseEnter()
    {
        
        isonobject=true;
        //Destroy(gameObject); //COMMENT THIS IF YOU WANT ON CLICK CUTTING
        //Debug.Log("mouse enter");
    }

    private void OnMouseExit()
    {
        
        //Debug.Log("mouse exit");
        isonobject=false;
    }

}
