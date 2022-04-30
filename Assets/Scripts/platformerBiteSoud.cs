using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerBiteSoud : MonoBehaviour
{
    public HurtPlayer script;
   AudioSource biteTrigger;


    // Start is called before the first frame update
    void Start()
    {
        biteTrigger= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.enemyAttackedtrigger = true)
        {
            biteTrigger.Play();
        }
    }
}
