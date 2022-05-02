using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIGHTname : MonoBehaviour
{
    public GameObject title;
    public GameObject canvas;

    void Start()
    {
        
        var color = title.GetComponent<RawImage>().color;
            color.a = 1f;
            title.GetComponent<RawImage>().color = color;

            StartCoroutine(DisablePlease());

        
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

    private IEnumerator DisablePlease()
        {
            yield return new WaitForSeconds(3);
            canvas.SetActive(false);
        }
   
}
