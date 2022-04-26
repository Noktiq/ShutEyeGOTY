using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMachineUI2 : MonoBehaviour
{
    public GameObject CelesteUI;
    public GameObject VictorUI;
    public GameObject BernardUI;
    public bool PortalActivated2;
    public GameObject BernardPortal;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        PortalActivated2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void Leftclick()
    {
        BernardUI.SetActive(false);
        VictorUI.SetActive(true);
    }

    public void ActivateBernard()
    {
        
        PortalActivated2 = true;
        Time.timeScale = 1f;
        BernardPortal.SetActive(true);
        // animator.Play("overworldcam");
        player.SetActive(true);
        BernardUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        
    }
}
