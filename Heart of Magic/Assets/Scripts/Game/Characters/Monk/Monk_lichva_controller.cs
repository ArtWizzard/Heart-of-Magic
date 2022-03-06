using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_lichva_controller : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    private bool isIn;

    [Header("Dialogue")]
    [SerializeField] private DecisionDialogueManager DM;
    [SerializeField] GameObject starting;
    [SerializeField] GameObject[] dialogueHolder;
    private List<GameObject> waiting;
    private GameObject child;
    private int childCount;

    //private bool dialogueRuns = false;
    private int i = 0;

    private void Awake()
    {
        waiting = new List<GameObject>();
        childCount = dialogueHolder.Length;
        if (DM == null)
            DM = GameObject.Find("DialogueManager").GetComponent<DecisionDialogueManager>();
        Again();
    }

    private void Update()
    {
        bool running = DM.GetComponent<DecisionDialogueManager>().isRunning;
        //bool closing = DM.GetComponent<DecisionDialogueManager>().toClose;
        if (isIn && Input.GetKeyDown(KeyCode.Space) && !running)
        {
            starting.GetComponent<DecisionDialogueTrigger>().TriggerDialogue();
            starting.GetComponent<SoundTrigger>().StartDialogue();
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

    public void RekniNapovedu()
    {
        int position = Random.Range(0, waiting.Count); // Random.Range(x, y) -> random x to (y-1)
        waiting[position].GetComponent<DecisionDialogueTrigger>().TriggerDialogue();
        waiting[position].GetComponent<SoundTrigger>().StartDialogue();

        waiting.Remove(waiting[position]);
        if (waiting.Count == 0)
            Again();
    }

    private void Again()
    {
        for (i = 0; i < dialogueHolder.Length; i ++)
            waiting.Add(dialogueHolder[i]);
    }
}
