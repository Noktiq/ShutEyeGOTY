using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsDone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
            // PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log("your int value is" + PlayerPrefs.GetInt("LevelCounter"));
        if (PlayerPrefs.GetInt("LevelCounter") >= 3)
        {
            SceneManager.LoadScene("FinalCutscene");
        }
    }



    //  public static void AddInt(string key, int numberToAdd)
    //     {
    //         //Check if the key exist
    //         if (UnityEngine.PlayerPrefs.HasKey(key))
    //         {
    //             //Read old value
    //             int value = UnityEngine.PlayerPrefs.GetInt(key);

    //             //Increment
    //             value += numberToAdd;

    //             //Save it back
    //             UnityEngine.PlayerPrefs.SetInt(key, value);
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
