using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class detectionFight : MonoBehaviour
{

    public bool playerInDetectionFight = false;
    public DateTime nextDamage;
    public float fightAfterTime;


    // Start is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerInDetectionFight == true)
        {
            FightInDetectionFight();
        }
    }
    

    private void OnTriggerEnter (Collider other )
    {
        if (other.tag == "Player")
        {
            playerInDetectionFight = true;
        }
    }

    private void OnTriggerExit (Collider other )
    {
        if (other.tag == "Player")
        {
            playerInDetectionFight = false;
        }
    }
    public void FightInDetectionFight()
    {
        if (nextDamage <= DateTime.Now)
        {
            //attacking enemyCode
            nextDamage= DateTime.Now.AddSeconds(System.Convert.ToDouble(fightAfterTime));
        }
    }
}
