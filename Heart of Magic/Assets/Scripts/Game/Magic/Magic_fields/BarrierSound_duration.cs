using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSound_duration : MonoBehaviour
{
    private float duration;
    private float time;
    public AudioSource audi;
    public AudioClip barrier;

    [SerializeField] private DataStorage storage;
    

    private void Awake()
    {
        duration = GetComponent<Barrier>().duration;
        audi.mute = false;
        audi.volume = storage.volume;
    }

    private void Update()
    {
        if (time >= duration)
            audi.mute = true;
        time += Time.deltaTime;
    }

    public void StartSound()
    {
        audi.mute = false;
        audi.PlayOneShot(barrier);
        time = 0;
    }
}
