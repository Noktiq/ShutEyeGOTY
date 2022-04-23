using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class dialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject ThirdpersonCam;
    public bool CelConvoEnded;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); 
        CelConvoEnded = false;
    }


    public void StartDialogue (Dialogue dialogue)
    {

        if(CelConvoEnded == false)
        {
        nameText.text = dialogue.name;

        Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            ThirdpersonCam.GetComponent<CinemachineFreeLook>().enabled = false;
        

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
        }
    }

    public void DisplayNextSentence ()
    {
        if ( sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CelConvoEnded = true;
        ThirdpersonCam.GetComponent<CinemachineFreeLook>().enabled = true;
    }
    
}
