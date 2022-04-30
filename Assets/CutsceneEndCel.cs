using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEndCel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitCelCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator waitCelCutscene()
    {
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene("HubReturn");
    }
}
