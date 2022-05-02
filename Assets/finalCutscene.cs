using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitFinalCutscene());
        Debug.Log("your int value is" + PlayerPrefs.GetInt("LevelCounter"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator waitFinalCutscene()
    {
        // PlayerPrefs.SetString("LevelManager", "CelesteDone");
        Debug.Log("your int value is" + PlayerPrefs.GetInt("LevelCounter"));
        yield return new WaitForSeconds(19);
        SceneManager.LoadScene("MainMenu");
        
    }
}
