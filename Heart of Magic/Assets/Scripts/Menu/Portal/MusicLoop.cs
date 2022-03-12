using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource musicSource;
    //public AudioClip musicStart;

    [SerializeField] private DataStorage storage;

    void Start()
    {
        //musicSource.PlayOneShot(musicStart);

        musicSource.PlayScheduled(AudioSettings.dspTime/* + musicStart.length*/);
        musicSource.volume = storage.volume;
    }
}
