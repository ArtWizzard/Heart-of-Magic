using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPlace_exitDetector : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private DialogueManager DM;
    [SerializeField] private Magic_altar_controller MAC;

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
            MAC.dialogueRuns = false;
            MAC.goddess.GetComponent<Goddess_teleportation>().HideGoddess();
            //Debug.Log("Exit");        
        }
    }
}
