using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatPortalFade : MonoBehaviour
{
    public bool fadeOut;
    public float fadeSpeed;
    public GameObject combatReturn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        FadeOutObject();


    }

    public void FadeOutObject()
    {
        fadeOut = true;
        Color objectColor = this.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        this.GetComponent<Renderer>().material.color = objectColor;
        Debug.Log("Fade");

        if(objectColor.a <= 0)
        {
            Destroy(combatReturn);
        }
    }
}
