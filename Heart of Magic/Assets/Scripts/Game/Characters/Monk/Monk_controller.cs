using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_controller : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    private bool isIn;

    [Header("Dialogue")]
    [SerializeField] private DialogueManager DM;
    [SerializeField] private GameObject dialogueHolder;
    private Transform child;
    private int childCount;

    private bool dialogueRuns = false;
    private int i;

    private void Awake()
    {
        childCount = dialogueHolder.transform.childCount;
        if (DM == null)
            DM = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        i = 0;

        /*
        for (int i = 0; i < dialogueHolder.childCount; i++)
        {
            child.
        }
        */
    }

    private void Update()
    {
        if (dialogueRuns)   // běží dialog
        {
            if (DM.GetComponent<DialogueManager>().isRunning == false)      //  domluvila osoba
            {
                if (i < childCount)         //  je potřeba něco říct
                {
                    child = dialogueHolder.transform.GetChild(i);
                    child.GetComponent<DialogueTrigger>().TriggerDialogue();
                    child.GetComponent<SoundTrigger>().StartDialogue();
                    i ++;
                } else {
                    dialogueRuns = false;   //  není - skonči
                    i = 0;
                }
            }
        } else {
            if (isIn && Input.GetKeyDown(KeyCode.Space))
            {
                dialogueRuns = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isIn = true;
            hint.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isIn = false;
            hint.SetActive(false);
        }
    }
}
