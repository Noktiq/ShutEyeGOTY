using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScreen : MonoBehaviour
{
   public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
