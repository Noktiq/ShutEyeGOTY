using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement1 : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 8;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public Vector3 linearVelocity;
    public bool isWalking;
    public bool playerJumping;
    Animator s_Animator;
    public bool movingNow;
    
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        s_Animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal"); //Keyboard input to determine if player is moving
        float inputY = Input.GetAxis("Vertical");

    
    //     print(linearVelocity);

    //     if(linearVelocity.x!=0 && linearVelocity.z!=0 && linearVelocity.y!=0 && isGrounded == true)
    //  { 
    //    isWalking = true;
    //    Debug.Log("walking");
    //  }
     
    //  if(linearVelocity.x==0 && linearVelocity.z==0)
    //  {
    //    isWalking = false;
    //    Debug.Log("NOT WALKING");
    //  }

        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // if (isGrounded && velocity.y < 0)
        // {
        //     velocity.y = -2f;
        //     s_Animator.SetBool("playerJumping", false);
        // }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            s_Animator.SetBool("playerJumping", true);
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }

        if(inputX  != 0 || inputY != 0){
            movingNow = true;    
            s_Animator.SetBool("isWalking", true);
        }
        else if(inputX == 0 && inputY == 0){
            movingNow = false;   
            s_Animator.SetBool("isWalking", false);
        }

        // if(direction.magnitude >= 0.1f)
        // {
            
        //     s_Animator.SetBool("isWalking", true);

        // }

            
            
        //returns player to hub

        Scene currentScene = SceneManager.GetActiveScene ();

        string sceneName = currentScene.name;

            if (Input.GetButtonDown("Fire2") && (sceneName != "Hub") && (sceneName != "HubReturn") )
        {
            SceneManager.LoadScene("HubReturn");
            Debug.Log("HubReturn");
        }

        
    }


    
    //teleports player back to hub
    
}