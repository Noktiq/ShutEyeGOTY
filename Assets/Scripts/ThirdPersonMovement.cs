using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Rendering;

public class ThirdPersonMovement : MonoBehaviour
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
    public bool BooActivate;
    
    public GameObject Player;

    public bool playerHurted;
    public killPlatformerEnemy script;

    public Vector3 moveDir;

    public GameObject scienceMesh;
    public Renderer rendererShadow;

    public killPlatformerEnemy script2;
    public killPlatformerEnemy script3;
    public killPlatformerEnemy script4;
    public killPlatformerEnemy script5;

    
    public int currentHealth;
      public int maxHealth = 5;

      [SerializeField] private Transform pos1;
  [SerializeField] private Transform pos2;
  [SerializeField] private Transform pos3;
  [SerializeField] private Transform pos4;
   [SerializeField] private Transform player;
   private int checkpointCount = 1;
    



    

    

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
     CharacterController CC = player.GetComponent<CharacterController>();
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;
        CC.enabled = true;

         if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }



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


        if(script.enemyKilled == true || script2.enemyKilled == true || script3.enemyKilled == true || script4.enemyKilled == true || script5.enemyKilled == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            Debug.Log("attempting to bounce");
        }

        // if(script2.enemyKilled == true)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //     Debug.Log("attempting to bounce");
        // }
        // if(script3.enemyKilled == true)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //     Debug.Log("attempting to bounce");
        // }
        // if(script4.enemyKilled == true)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //     Debug.Log("attempting to bounce");
        // }

        // if(script5.enemyKilled == true)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        //     Debug.Log("attempting to bounce");
        // }
        

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

        
   
       if (currentHealth <=0)
       {
           SceneManager.LoadScene("PlatformerDream");
           //BooActivate = true;
       }
    }

    public void HurtPlayer(int damage)
   {
       currentHealth -= damage;
       UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
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

 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shadow")
        {
           scienceMesh.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        //    rendererShadow.shadowCastingMode<ShadowsOnly>();
        }
        {
       CharacterController CC = player.GetComponent<CharacterController>();
       if (other.gameObject.tag == "CheckPoint")
        {
            BoxCollider BC = other.gameObject.GetComponent<BoxCollider>();
            BC.enabled = false;
            checkpointCount++;
        }
        if (other.gameObject.tag == "Death")
        {
            if (checkpointCount == 2)
            {
                CC.enabled = false;
                player.transform.position = pos2.transform.position;
                CC.enabled = true;
            }
            else  if (checkpointCount == 3)
            {
                CC.enabled = false;
                player.transform.position = pos3.transform.position;
                CC.enabled = true;
            }
              else if (checkpointCount == 4)
            {
                CC.enabled = false;
                player.transform.position = pos4.transform.position;
                CC.enabled = true;
            }
            else
            {
                 CC.enabled = false;
                player.transform.position = pos1.transform.position;
                CC.enabled = true;
            }
        }
   }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shadow")
        {
           scienceMesh.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        //    rendererShadow.shadowCastingMode<ShadowsOnly>();
        }
    }

  
    

    

}