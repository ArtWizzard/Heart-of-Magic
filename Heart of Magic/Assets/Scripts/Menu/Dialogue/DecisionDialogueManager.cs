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
    public bool toClose = false;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        
        if(isRunning)
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                GameObject.Find("Monk").GetComponent<Monk_lichva_controller>().RekniNapovedu();
                isRunning = false;
                toClose = true;
                //DisplayNextSentence();
            }
            else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space))
                EndDialogue();
        }

        if (Input.GetKeyDown(KeyCode.Space) && toClose)
        {
            EndDialogue();
            toClose = false;
        }
            
    }

    public void StartDialogue (Dialogue dialogue)  // vykreslení věty
    {
        isRunning = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name; 
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(); // vykreslí
    }

    public void DisplayNextSentence()   // vykreslí jednu
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)  // vykresluje po písmenkách
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()      // skryje dialogue
    {
        animator.SetBool("IsOpen", false);
        isRunning = false;
    }
}
