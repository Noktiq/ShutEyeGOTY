using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class checkenemyDeath : MonoBehaviour
{
    public BigEnemyRobot script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(script.BigcurrentHealth <=0)
        {
            StartCoroutine(waitbeforeDefeat());
        }
    }

    IEnumerator waitbeforeDefeat()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("HubReturning");

    }
}
