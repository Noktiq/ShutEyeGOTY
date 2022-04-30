using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIdleSound : MonoBehaviour
{
    AudioSource IdleTrigger;
    public killPlatformerEnemy script;

    // Start is called before the first frame update
    void Start()
    {
       IdleTrigger= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        // if(script.enemyKilledSound == true)
        // {
        //     IdleTrigger.Stop();
        // }

        if(script.enemyKilledSound == true)
        {
            stopIdleSound();
        }
    }


    public void stopIdleSound()
    {
        if(script.enemyKilledSound == true)
        {
            IdleTrigger.Stop();
        }
    }
}
