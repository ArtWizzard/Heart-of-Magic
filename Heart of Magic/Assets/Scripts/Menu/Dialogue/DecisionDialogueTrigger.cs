using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DecisionDialogueManager>().StartDialogue(dialogue);
    }
}
