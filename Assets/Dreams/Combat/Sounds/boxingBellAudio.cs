using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxingBellAudio : MonoBehaviour
{
    AudioSource BellaudioSource;
    public BigEnemyRobot script;
    // Start is called before the first frame update
    void Start()
    {
        BellaudioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.enemyKnocked == true)
        {
            //Debug.Log("hurt audio triggered");
            BellaudioSource.Play();
        }
    }
}
