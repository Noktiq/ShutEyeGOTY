using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlatformerEnemy : MonoBehaviour
{
    public GameObject enemy;
    public bool enemyKilled;
    AudioSource enemyBounce;
    public bool enemyKilledSound;
    // Start is called before the first frame update
    void Start()
    {
        enemyBounce = GetComponent<AudioSource>();
        enemyKilledSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //enemyKilled = true;
            //Destroy(enemy);
            enemyBounce.Play();
            enemyKilledSound = true;
            
            StartCoroutine(enemyKilledReset());
        }

    }

    IEnumerator enemyKilledReset()
    {
        enemyKilled = true;
        
        yield return new WaitForSeconds(.03f);
        enemyKilled = false;
    }
}
