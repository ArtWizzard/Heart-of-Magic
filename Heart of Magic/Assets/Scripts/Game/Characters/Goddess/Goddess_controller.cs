using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goddess_controller : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] public GameObject goddess;
    //[SerializeField] private GameObject[] dialogueHolders;

    [Header("Dialogue")]
    [SerializeField] private DialogueManager DM;
    [SerializeField] GameObject[] dialogueHolder;
    private GameObject child;
    private int childCount;
    private int direction;

    public bool dialogueRuns = false;
    private int i = 0;

    private void Awake()
    {
        childCount = dialogueHolder.Length;

        if (DM == null)
            DM = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (dialogueRuns)   // běží dialog
        {
            if (DM.GetComponent<DialogueManager>().isRunning == false)      //  domluvila osoba
            {
                if (i < childCount)         //  je potřeba něco říct
                {
                    child = dialogueHolder[i];
                    child.GetComponent<DialogueTrigger>().TriggerDialogue();
                    child.GetComponent<SoundTrigger>().StartDialogue();
                    i ++;
                } else {
                    dialogueRuns = false;   //  není - skonči
                    i = 0;
                    goddess.GetComponent<Goddess_teleportation>().HideGoddess();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !goddess.activeInHierarchy)
        {
            if (collision.transform.position.x < transform.position.x)
                direction = -1;
            else
                direction = 1;

            i = 0;
            goddess.GetComponent<Goddess_teleportation>().ShowGoddess(transform, direction);
            dialogueRuns = true;
        }
        //  gameObject.GetComponent<ScriptName>().variable
        //  player.transform.position = respawnPoint.position;
        //  player.SetActive(false);  
    }
}
