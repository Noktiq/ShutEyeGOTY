using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Rendering;

public class ThirdPersonMovement2 : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 8;
    Vector3 velocity;
    public bool isGrounded;

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
    
    public int currentHealth;
    public int maxHealth;

    public GameObject Player;

    public bool playerHurted;
    public killPlatformerEnemy script;

    public Vector3 moveDir;



    

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        s_Animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
        playerHurted = false;
        
    }
    // Update is called once per frame
    void Update()
    {

        // if(currentHealth <=0)
        // {
        //     SceneManager.LoadScene("PlatformerDream");
        // }

        // float h = Input.GetAxisRaw("Horizontal");
        // float v = Input.GetAxisRaw("Vertical");

        // Vector3 dir = new Vector3(h, 0, v).normalized;

        //  if (dir.magnitude >= 0.1f)
        // {
        //     float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //     transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //     moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        //     controller.Move(moveDir.normalized * speed * Time.deltaTime);
        // }



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

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            s_Animator.SetBool("playerJumping", false);
        }

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
            s_Animator.SetBool("scienceWalk", true);
            s_Animator.SetBool("isWalking", true);
            isWalking = true;
        }
        else if(inputX == 0 && inputY == 0){
            movingNow = false;   
            s_Animator.SetBool("scienceWalk", false);
            s_Animator.SetBool("isWalking", false);
            isWalking = false;
        }


        if(script.enemyKilled == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
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

    public void HurtPlayer(int damage)
   {
       currentHealth -= damage;
    //    playerHurted = true;
        if (playerHurted == false)
        {
       StartCoroutine(waitBeforeHurt());
        }
    
   }

   IEnumerator waitBeforeHurt()
   {
    //    currentHealth -= damage;
       playerHurted = true;
       yield return new WaitForSeconds(1f);
       playerHurted = false;
   }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
           Player.transform.position = CheckPoint.GetActiveCheckPointPosition();
        }
    }

}