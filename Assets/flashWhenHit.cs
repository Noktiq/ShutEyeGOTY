using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashWhenHit : MonoBehaviour
{

    public float flashTime;
    public ThirdPersonMovement script;
    // public GameObject scienceMesh;
    // Color originalColor;
    // public SkinnedMeshRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        // originalColor = renderer.color;
        // renderer = GetComponent<SkinnedMeshRenderer>();
        // originalColor = renderer.material.color();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.playerHurted == true)
        {
            FlashStart();
            //Debug.Log("A");
        }

        
    }

    void FlashStart()
    {
        gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        Invoke("FlashStop", flashTime);

    }
  

    void FlashStop()
    {
        gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Shadow")
    //     {
    //        scienceMesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
    //     }
    // }
}
