using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_lichva_controller : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    private bool isIn; // musím se nacházet ven, abych to spustil

    [Header("Dialogue")]
    [SerializeField] private DecisionDialogueManager DDM;
    [SerializeField] private GameObject[] dialogueHolder;
    [SerializeField] private GameObject question;
    private Transform child;
    private int childCount;

    [Header ("Data Storage")]
    [SerializeField] private DataStorage storage;
    [SerializeField] private InventoryManager IM;
    [SerializeField] private int tax;

    private List<GameObject> waiting;

    public bool dialogueRuns = false;
    public bool questionRuns = false;
    private bool asked = true;
    //private int i;

    //private int fase;

    private void Awake()
    {
        //childCount = dialogueHolder.transform.childCount;
        if (DDM == null)
            DDM = GameObject.Find("DialogueManager").GetComponent<DecisionDialogueManager>();

        //i = 0;
        //fase = 0;
        waiting = new List<GameObject>();
        Again();
    }

    private void Update()
    {
        if (dialogueRuns)   // běží dialog
        {
            //Debug.Log(DDM.isRunning);
            if (DDM.isRunning == false)      //  domluvila osoba
            {
                Discussion();
            }
        } 
        else if (questionRuns)
        {
            if (asked)
            {
                question.GetComponent<DecisionDialogueTrigger>().TriggerDialogue();
                question.GetComponent<SoundTrigger>().StartDialogue();
                asked = false;
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                //Debug.Log("54 MLC O");

                if (storage.runesAmmount >= tax)
                {
                    storage.runesAmmount -= tax;
                    IM.Actualize();

                    dialogueRuns = true;
                    questionRuns = false;
                    DDM.EndDialogue();
                }
            }
            else if (Input.GetKeyDown(KeyCode.X) || (Input.GetKeyDown(KeyCode.Space) && !DDM.letterProgress))
            {
                dialogueRuns = false;
                questionRuns = false;
                DDM.EndDialogue();
            }
        }
        else {
            if (isIn && Input.GetKeyDown(KeyCode.Space) && !DDM.letterProgress && !DDM.isRunning)
            {
                questionRuns = true;
                asked = true;
            }
        }
    }

    private void Discussion()
    {
        /*
        child = dialogueHolder.transform.GetChild(2);
        child.GetComponent<DecisionDialogueTrigger>().TriggerDialogue();
        child.GetComponent<SoundTrigger>().StartDialogue();
*/
        int position = Random.Range(0, waiting.Count); // Random.Range(x, y) -> random x to (y-1)
        waiting[position].GetComponent<DecisionDialogueTrigger>().TriggerDialogue();
        waiting[position].GetComponent<SoundTrigger>().StartDialogue();

        waiting.Remove(waiting[position]);
        if (waiting.Count == 0)
            Again();
        
        dialogueRuns = false;
    }


    private void Again()
    {
        for(int i = 0; i < dialogueHolder.Length; i ++)
        {
            waiting.Add(dialogueHolder[i]);
            //Debug.Log(i);
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

    /*

    public void RekniNapovedu()
    {
        int position = Random.Range(0, waiting.Count); // Random.Range(x, y) -> random x to (y-1)
        waiting[position].GetComponent<DecisionDialogueTrigger>().TriggerDialogue();
        waiting[position].GetComponent<SoundTrigger>().StartDialogue();

        waiting.Remove(waiting[position]);
        if (waiting.Count == 0)
            Again();
    }
    */
}
