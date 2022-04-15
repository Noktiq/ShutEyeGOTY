using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyTrigger1 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
    Destroy(other.gameObject);
    
    if(other.gameObject.tag == "Player")
        {
         SceneManager.LoadScene("PlatformerDream");
        }

    }
}
