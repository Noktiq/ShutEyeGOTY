using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorFightCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForNext());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(32);
        SceneManager.LoadScene("CombatPart2");
        

    }
}
