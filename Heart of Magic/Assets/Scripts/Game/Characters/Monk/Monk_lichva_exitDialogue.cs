using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_lichva_exitDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private DecisionDialogueManager DDM;
    [SerializeField] private Monk_lichva_controller MLC;

    private CircleCollider2D cc;

    private void Awake()
    {
        if (DDM == null)
            DDM = GameObject.Find("DialogueManager").GetComponent<DecisionDialogueManager>();

        //cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            DDM.isRunning = false;
            DDM.EndDialogue();
            MLC.dialogueRuns = false;
            MLC.questionRuns = false;
        }
    }
}
