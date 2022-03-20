using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionDialogueManager : MonoBehaviour
{
    private Queue<string> sentences; 
    
    public Text nameText;
    public Text dialogueText;
    
    public Animator animator;

    public bool isRunning;
    public bool smthToSay;

    private float letterDrawing = 0.05f;
    public bool letterProgress = false;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        
        if(isRunning)
            if(Input.GetKeyDown(KeyCode.Space))
                if (letterProgress)
                {
                    letterProgress = false;
                } else 
                {
                    DisplayNextSentence();
                }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        isRunning = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name; 
        //Debug.Log("starting conversation with: " + dialogue.name);
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            //Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }
        //Debug.Log("nextSent");
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            smthToSay = false;
            return;
        }
        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;     //  whole sentence
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        letterDrawing = 0.05f;
        dialogueText.text = "";
        letterProgress = true;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            if (letterProgress == false)
            {
                //Debug.Log("print");
                dialogueText.text = sentence;
                break;
            }
            yield return new WaitForSeconds(letterDrawing);
        }
        letterProgress = false;
    }

    public void EndDialogue()
    {
        //Debug.Log("End of dialogue");
        animator.SetBool("IsOpen", false);
        isRunning = false;
    }
}
