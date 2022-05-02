using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup1: MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider collider;
    public Transform player;
    public float pickUpRange;


    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
                  
        if (distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E))) PickUp1();

    }

    private void PickUp1()
    {
        
        SceneManager.LoadScene("Loop3");
              
    }
    

}
