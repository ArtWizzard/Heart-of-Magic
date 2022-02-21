using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHit; // jumpSound, deathSound;
    private static AudioSource audioSrc;

    private void Start()
    {
        playerHit = Resources.Load<AudioClip>("Wizzard_hit");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "wizzard_hit":
                audioSrc.PlayOneShot(playerHit);
                break;
        }
    }

    public static void PlayDialogue(AudioClip _dialogue)
    {
        audioSrc.PlayOneShot(_dialogue);
    }
}
