using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitIntroCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator waitIntroCutscene()
    {
        yield return new WaitForSeconds(96f);
        SceneManager.LoadScene("Hub");
    }
}
