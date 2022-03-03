using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_altar_controller : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject goddess;
    [SerializeField] private GameObject[] dialoguesHolder;
    [SerializeField] private DialogueManager DM;
    [SerializeField] private GameObject activation;
    private int diaCount;
    private int direction;
    private bool once;

    private bool dialogueRuns = false;
    private int i = 0;

    private void Awake()
    {
        diaCount = dialoguesHolder.Length;

        if (DM == null)
        {
            DM = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        }

        if (goddess == null)
        {
            goddess = GameObject.Find("Goddess");
        }
    }

    private void Update()
    {
        if (dialogueRuns)   // běží dialog
        {
            if (DM.GetComponent<DialogueManager>().isRunning == false)      //  domluvila osoba
            {
                if (i < diaCount)         //  je potřeba něco říct
                {
                    dialoguesHolder[i].GetComponent<DialogueTrigger>().TriggerDialogue();
                    dialoguesHolder[i].GetComponent<SoundTrigger>().StartDialogue();
                    i ++;
                } else {
                    dialogueRuns = false;   //  není - skonči
                    i = 0;
                    goddess.GetComponent<Goddess_teleportation>().HideGoddess();
                    //activation.SetActive(false);
                }
            }
        }
        if (!goddess.activeInHierarchy && once)
        {
            activation.SetActive(false);
            once = false;
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

            activation.SetActive(true);
            goddess.GetComponent<Goddess_teleportation>().ShowGoddess(transform, direction);
            dialogueRuns = true;
            once = true;
            //Debug.Log(transform);
        }
    }
}
