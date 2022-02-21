using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip[] dialogues;

    public void StartDialogue()
    {
        if (dialogues.Length != 0)
            SoundManager.PlayDialogue(dialogues[0]);
    }
}
