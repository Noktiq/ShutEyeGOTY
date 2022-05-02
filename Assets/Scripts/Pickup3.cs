using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup3 : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider collider;
    public Transform player;
    public float pickUpRange;


    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
                  
        if (distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.E))) PickUp();

    }

    private void PickUp()
    {
        PlayerPrefs.SetInt("LevelCounter", (PlayerPrefs.GetInt("LevelCounter") + 1));
        Debug.Log("your int value is" + PlayerPrefs.GetInt("LevelCounter"));
        
        SceneManager.LoadScene("HubReturnal");
              
    }
    

}
