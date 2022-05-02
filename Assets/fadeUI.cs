using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fadeUI : MonoBehaviour
{
    public GameObject combatTut;
    // Start is called before the first frame update
    void Start()
    {
        var color = combatTut.GetComponent<RawImage>().color;
            color.a = 1f;
            combatTut.GetComponent<RawImage>().color = color;
    }
    
    void Update()
    {
        if(combatTut != null)
        {
            if (combatTut.GetComponent<RawImage>().color.a>0)
            {
                var color = combatTut.GetComponent<RawImage>().color;
                color.a -= 0.0009f;
                combatTut.GetComponent<RawImage>().color = color;
            }
        }

        
    }
}
