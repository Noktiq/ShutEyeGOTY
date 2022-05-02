using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D defaultCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Player") 
         {
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
              Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
              cam.fieldOfView = 90;
         }
     }


         void OnTriggerExit(Collider other) 
         {
         if(other.tag == "Player")
         {
         
             
             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
             Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
         }
         }

         
}
