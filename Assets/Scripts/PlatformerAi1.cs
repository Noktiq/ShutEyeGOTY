using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformerAi1 : MonoBehaviour
{
    public Transform[] moveSpots;
    private int randomSpot;
    public float waitTime;
    public float startWaitTime;

    public float speed;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        while (true)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            while(Vector3.Distance(transform.position, moveSpots[randomSpot].position) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}