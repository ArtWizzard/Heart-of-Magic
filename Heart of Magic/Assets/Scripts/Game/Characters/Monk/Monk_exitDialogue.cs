using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_exitDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private DialogueManager DM;
    [SerializeField] private Monk_controller MC;

    private CircleCollider2D cc;

    private void Awake()
    {
        if (DM == null)
            DM = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            DM.isRunning = false;
            DM.EndDialogue();
            MC.dialogueRuns = false;
        }
    }
}
