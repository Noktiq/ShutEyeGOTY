using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEndCel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LevelCounter", (PlayerPrefs.GetInt("LevelCounter") + 1));
        StartCoroutine(waitCelCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator waitCelCutscene()
    {
        // PlayerPrefs.SetString("LevelManager", "CelesteDone");
        Debug.Log("your int value is" + PlayerPrefs.GetInt("LevelCounter"));
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene("HubReturnal");
        
    }

    // public static void AddInt(string key, int numberToAdd)
    //     {
    //         //Check if the key exist
    //         if (UnityEngine.PlayerPrefs.LevelCounter(key))
    //         {
    //             //Read old value
    //             int value = UnityEngine.PlayerPrefs.GetInt(LevelCounter);

    //             //Increment
    //             value += numberToAdd;

    //             //Save it back
    //             UnityEngine.PlayerPrefs.SetInt(LevelCounter, value);
    //         }
    //     }

    //     public static void SubstractInt(string key, int numberToSubstract)
    //     {
    //         //Check if the key exist
    //         if (UnityEngine.PlayerPrefs.HasKey(key))
    //         {
    //             //Read old value
    //             int value = UnityEngine.PlayerPrefs.GetInt(key);

    //             //De-Increment
    //             value -= numberToSubstract;

    //             //Save it back
    //             UnityEngine.PlayerPrefs.SetInt(key, value);
    //         }
    //     }
}
