using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkmarkUI : MonoBehaviour
{
    public GameObject checkUI;
    AudioSource DingTrigger;
    public ThirdPersonMovement script;

    // Start is called before the first frame update
    void Start()
    {
        checkUI.SetActive(false);
       DingTrigger= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           StartCoroutine(waitforShowUI());
        }
    }

    private IEnumerator waitforShowUI()
    {
        checkUI.SetActive(true);
        DingTrigger.Play();
        yield return new WaitForSeconds(1);
        checkUI.SetActive(false);
    }
}
