using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class labname : MonoBehaviour
{
     public GameObject title;

    void Start()
    {
        var color = title.GetComponent<RawImage>().color;
            color.a = 1f;
            title.GetComponent<RawImage>().color = color;
    }
    
    void Update()
    {
        if(title != null)
        {
            if (title.GetComponent<RawImage>().color.a>0)
            {
                var color = title.GetComponent<RawImage>().color;
                color.a -= 0.008f;
                title.GetComponent<RawImage>().color = color;
            }
        }

        
    }
   
}
