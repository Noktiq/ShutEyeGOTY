using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformerAi1 : MonoBehaviour
{
    public Transform[] moveSpots;
    private int randomSpot;
    public float waitTime;
    public float startWaitTime;
    public killPlatformerEnemy script;
    public float speed;
    Animator enemyanims;
    public GameObject killExplosion;
    public GameObject enemyKiller;
    

    void Start()
    
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        transform.LookAt(moveSpots[randomSpot]);
        enemyanims = gameObject.GetComponent<Animator>();
        enemyanims.SetBool("enemyDed", false);
       
       
    }

    private void Update()
    {

        

        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        // Check if the distance between this and the movepoint is less than 0.2f (tollerange range)


        if (script.enemyKilled == false)
        {
        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                transform.LookAt(moveSpots[randomSpot]);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime = -Time.deltaTime;
            }
        }
        }

        if (script.enemyKilled == true)
        {
            Debug.Log("RegisterKill");
            speed = 0f;
            StartCoroutine(WaitforExplosion());
        }


        if (script.enemyKilled == true)
        {
            enemyanims.SetBool("enemyDed", true);
        }


       
    }

     IEnumerator WaitforExplosion()
     {
    yield return new WaitForSeconds(1);
    killExplosion.SetActive(true);
    yield return new WaitForSeconds(.6f);
    Destroy(gameObject);
     }

     

}
