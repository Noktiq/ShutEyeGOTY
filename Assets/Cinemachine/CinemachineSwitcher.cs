using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{

    private Animator animator;


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
         }
        
     }

     void OnTriggerExit(Collider other) {
         if(other.tag == "Player")
         {
         
             animator.Play("ThirdPersonCam");
             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
         }
         
     }
}
