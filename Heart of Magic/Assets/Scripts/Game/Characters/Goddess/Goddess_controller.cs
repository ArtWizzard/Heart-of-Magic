using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goddess_controller : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject goddess;
    //[SerializeField] private GameObject[] dialogueHolders;
    [SerializeField] private DialogueManager DM;
    private Transform child;
    private int childCount;

    private bool dialogueRuns = false;
    private int i = 0;

    private void Awake()
    {
        childCount = transform.childCount;
    }

    private void Update()
    {
        if (dialogueRuns)   // běží dialog
        {
            if (DM.GetComponent<DialogueManager>().isRunning == false)      //  domluvila osoba
            {
                if (i < childCount)         //  je potřeba něco říct
                {
                    //  dialogueHolders.Length
                    //  dialogueHolders[i].GetComponent<DialogueTrigger>().TriggerDialogue();
                    child = transform.GetChild(i);
                    child.GetComponent<DialogueTrigger>().TriggerDialogue();
                    i ++;
                } else {
                    dialogueRuns = false;   //  není - skonči
                    i = 0;
                    goddess.SetActive(false);
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            goddess.SetActive(true);
            goddess.transform.position = gameObject.transform.position;
            dialogueRuns = true;

        //  gameObject.GetComponent<ScriptName>().variable
        //  player.transform.position = respawnPoint.position;
        //  player.SetActive(false);  
    }
}
