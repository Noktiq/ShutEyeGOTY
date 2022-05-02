using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class IntroCutscene : MonoBehaviour
{
    public GameObject skipUI;
    public bool skipInitiated;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitIntroCutscene());
        skipUI.SetActive(false);
        skipInitiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") )
        {
            StartCoroutine(DisplaySkipUI());
        }
        if(Input.GetButtonDown("Jump") && skipInitiated == true)
        {
        SceneManager.LoadScene("Hub");
        }
            
        
    }

    private IEnumerator waitIntroCutscene()
    {
        yield return new WaitForSeconds(96f);
        SceneManager.LoadScene("Hub");
    }

    private IEnumerator DisplaySkipUI()
    {
        yield return new WaitForSeconds(.5f);
        skipInitiated = true;
        skipUI.SetActive(true);
        yield return new WaitForSeconds(3);
        skipUI.SetActive(false);
    }
}
