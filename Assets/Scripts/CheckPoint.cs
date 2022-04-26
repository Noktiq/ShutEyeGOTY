using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Indicate if the checkpoint is activated
    public bool activated = false;
    
    public static GameObject[] CheckPointsList;



    void Start()
    {
        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    // Activate the checkpoint
    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
         //   cp.GetComponent().activated = false;
         //   cp.GetComponent().SetBool("Active", false);
        }

        // We activate the current checkpoint
        activated = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }

    // Get position of the last activated checkpoint
    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0, 0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
           //     if (cp.GetComponent().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }
}
