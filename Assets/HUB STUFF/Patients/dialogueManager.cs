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
    public GameObject BlueprintChatUI;
    public Animator animator;
    public bool convoTalking;
    
    
    public GameObject ThirdpersonCam;
    public bool CelConvoEnded;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); 
        CelConvoEnded = false;
        Application.targetFrameRate = 60;
        convoTalking = false;
    }

    void Update ()
    {
        if(Input.GetButtonDown("Jump"))
        {
            DisplayNextSentence();
        }
    }


    public void StartDialogue (Dialogue dialogue)
    {

        // if(CelConvoEnded == false)
        convoTalking = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        blueprinttextTrigger bt = FindObjectOfType <blueprinttextTrigger>();
        bt.Nowtalking();
        Debug.Log("convoTrigger");

        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;

        // ThirdpersonCam.GetComponent<CinemachineCameraOffset>().mx = 1;
        

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
        
        
    }

    public void DisplayNextSentence ()
    {
        if ( sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        blueprinttextTrigger bt = FindObjectOfType <blueprinttextTrigger>();
        bt.Nowtalking();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        convoTalking = true;
        // Debug.Log(sentence);
        // dialogueText.text = sentence;

    }
    

    public IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text="";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CelConvoEnded = true;
        // ThirdpersonCam.GetComponent<CinemachineFreeLook>().enabled = true;
        convoTalking = false;
        //BlueprintChatUI.SetActive(false);
    }
    
}
