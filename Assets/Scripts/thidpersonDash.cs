using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thidpersonDash : MonoBehaviour
{
    ThirdPersonMovement moveScript;
    public float dashSpeed;
    public float dashTime;
    Animator SAnimator;
    public GameObject speedEffect;
    public bool dashTimerON;
    AudioSource speedBoostSFX;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonMovement>();
        SAnimator = gameObject.GetComponent<Animator>();
        speedEffect.SetActive(false);
        speedBoostSFX = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && dashTimerON == false)
        {
            // SAnimator.SetBool("playerDashed", true);
            StartCoroutine(Dash());
            // SAnimator.SetBool("playerDashed", false);

        }

        
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        SAnimator.SetBool("playerDashed", true);
        speedBoostSFX.Play();
        // dashTimerON = true;
        // speedEffect.SetActive(true);
        StartCoroutine(dashTimer());
        StartCoroutine(speedLines());
        

        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(.3f);
        SAnimator.SetBool("playerDashed", false);
        // dashTimerON = false;
        // speedEffect.SetActive(false);
    }


    IEnumerator dashTimer()
    {
        dashTimerON = true;
        yield return new WaitForSeconds(.8f);
        dashTimerON = false;
    }

    IEnumerator speedLines()
    {
        speedEffect.SetActive(true);
        yield return new WaitForSeconds(.205f);
        speedEffect.SetActive(false);

    }
}
