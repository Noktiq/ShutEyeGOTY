using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
         transform.localPosition = new Vector3(0f,5f,0f);
         isBig = true;
     } 

     if (Input.GetButtonDown("Shrink"))
     {
         transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
         isBig = false;
     }

     Scene currentScene = SceneManager.GetActiveScene ();

        string sceneName = currentScene.name;

            if (Input.GetButtonDown("Fire2") && (sceneName != "Hub") && (sceneName != "HubReturn") )
        {
            SceneManager.LoadScene("HubReturn");
            Debug.Log("HubReturn");
        }

    }
}
