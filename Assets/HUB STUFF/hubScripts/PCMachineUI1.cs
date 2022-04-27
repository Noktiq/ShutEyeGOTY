using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMachineUI1 : MonoBehaviour
{
    public GameObject CelesteUI;
    public GameObject VictorUI;
    public GameObject BernardUI;
    public GameObject VictorPortal;
    public GameObject player;
    public bool PortalActivated1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rightclick()
    {
        VictorUI.SetActive(false);
        BernardUI.SetActive(true);
    }

    public void Leftclick()
    {
        CelesteUI.SetActive(true);
        VictorUI.SetActive(false);
    }

    public void ActivateVictor()
    {
        
        PortalActivated1 = true;
        Time.timeScale = 1f;
        VictorPortal.SetActive(true);
        // animator.Play("overworldcam");
        player.SetActive(true);
        VictorUI.SetActive(false);
        Cursor.visible = false;
          Cursor.lockState = CursorLockMode.None;
        
    }


}
