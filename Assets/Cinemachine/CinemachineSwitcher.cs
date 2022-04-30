using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{

    private Animator animator;
    public Texture2D cursorTexture;
    public Texture2D defaultCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }
 

     void OnTriggerEnter(Collider other) {
         if (other.tag == "Player") {
             animator.Play("2DCam");
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
              Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
         }
        
     }

     void OnTriggerExit(Collider other) {
         if(other.tag == "Player")
         {
         
             animator.Play("ThirdPersonCam");
             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
             Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
         }
         
     }
}
