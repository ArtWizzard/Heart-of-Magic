using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip wizzard_fc_sound, wizzard_hit_sound, wizzard_at_sound; // wizzard
    public static AudioClip wizzard_ai_sound, wizzard_kolena_sound, wizzard_break_sound, wizzard_ohh_zada_sound, wizzard_ty_zada_sound;// wizzard saying
    public static AudioClip magic_barrier_sound, /*magic_beam_sound,*/ magic_energy_sound, magic_shoot_sound; // magic
    public static AudioClip explode_1_sound, explode_2_sound, explode_3_sound; // explode
    public static AudioClip click_sound, choose_sound, /*portal_sound,*/ upgrade_sound; // menu
    public static AudioClip ghost_sound, impact_sound, tp_sound; // enemy


    private static AudioSource audioSrc;
    [SerializeField] private DataStorage storage;
    private float volume;
    //private float effectsVolume;
    //private float dialogueVolume;

    private void Start()
    {
        // wizzard
        wizzard_hit_sound = Resources.Load<AudioClip>("Wizzard_hit");
        wizzard_ai_sound = Resources.Load<AudioClip>("ai");
        wizzard_at_sound = Resources.Load<AudioClip>("att1");
        wizzard_kolena_sound = Resources.Load<AudioClip>("au_moje_kole");
        wizzard_ohh_zada_sound = Resources.Load<AudioClip>("ooh_moje_zada");
        wizzard_ty_zada_sound = Resources.Load<AudioClip>("ty_moje_zada");
        wizzard_break_sound = Resources.Load<AudioClip>("brok");
        wizzard_fc_sound = Resources.Load<AudioClip>("fc");
        // magic
        magic_barrier_sound = Resources.Load<AudioClip>("barrier"); // hotovo
        //magic_beam_sound = Resources.Load<AudioClip>("beam");
        magic_energy_sound = Resources.Load<AudioClip>("electro");
        magic_shoot_sound = Resources.Load<AudioClip>("shoot");
        // explode
        explode_1_sound = Resources.Load<AudioClip>("explo1");
        explode_2_sound = Resources.Load<AudioClip>("explo2");
        explode_3_sound = Resources.Load<AudioClip>("explo3");
        // enemy
        ghost_sound = Resources.Load<AudioClip>("ghist");
        impact_sound = Resources.Load<AudioClip>("impact");
        tp_sound = Resources.Load<AudioClip>("tp");
        // menu
        choose_sound = Resources.Load<AudioClip>("choose");
        click_sound = Resources.Load<AudioClip>("click");
        //portal_sound = Resources.Load<AudioClip>("portal");
        upgrade_sound = Resources.Load<AudioClip>("upgrade");


        audioSrc = GetComponent<AudioSource>();
        
        //storage = Resources.Load<DataStorage>("Scripts/Operation/New Data Storage");
/*
        effectsVolume = storage.effects * storage.volume;
        dialogueVolume = storage.dialogues * storage.volume;
        if (effectsVolume > 1)
            effectsVolume = 1;
        if (dialogueVolume > 1)
            dialogueVolume = 1;*/
        audioSrc.volume = storage.volume;
    }
/*
    private void Update()
    {
        audioSrc.volume = volume;
    }

    private void UpdateVolume(bool _effects)
    {
        if (_effects)
            volume = effectsVolume;
        else
        volume = dialogueVolume;
    }*/

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "wizzard_hit":
                audioSrc.PlayOneShot(wizzard_hit_sound);
                break;
            case "wizzard_ai":
                audioSrc.PlayOneShot(wizzard_ai_sound);
                break;
            case "wizzard_attack":
                audioSrc.PlayOneShot(wizzard_at_sound);
                break;
            case "wizzard_kolena":
                audioSrc.PlayOneShot(wizzard_kolena_sound);
                break;
            case "wizzard_zada1":
                audioSrc.PlayOneShot(wizzard_ohh_zada_sound);
                break;
            case "wizzard_zada2":
                audioSrc.PlayOneShot(wizzard_ty_zada_sound);
                break;
            case "wizzard_break":
                audioSrc.PlayOneShot(wizzard_break_sound);
                break;
            case "wizzard_fc":
                audioSrc.PlayOneShot(wizzard_fc_sound);
                break;
            case "magic_barrier":
                audioSrc.PlayOneShot(magic_barrier_sound);
                break;
                /*
            case "magic_beam":
                audioSrc.PlayOneShot(magic_beam_sound);
                break;*/
            case "magic_energy":
                audioSrc.PlayOneShot(magic_energy_sound);
                break;
            case "magic_shoot":
                audioSrc.PlayOneShot(magic_shoot_sound);
                break;
            case "explode1":
                audioSrc.PlayOneShot(explode_1_sound);
                break;
            case "explode2":
                audioSrc.PlayOneShot(explode_2_sound);
                break;
            case "explode3":
                audioSrc.PlayOneShot(explode_3_sound);
                break;
            case "ghost":
                audioSrc.PlayOneShot(ghost_sound);
                break;
            case "impact":
                audioSrc.PlayOneShot(impact_sound);
                break;
            case "tp":
                audioSrc.PlayOneShot(tp_sound);
                break;
            case "choose":
                audioSrc.PlayOneShot(choose_sound);
                break;
            case "click":
                audioSrc.PlayOneShot(click_sound);
                break;
            /*
            case "portal":
                audioSrc.PlayOneShot(portal_sound);
                break;*/
            case "upgrade":
                audioSrc.PlayOneShot(upgrade_sound);
                break;
            
        }
    }

    public static void PlayDialogue(AudioClip _dialogue)
    {
        audioSrc.PlayOneShot(_dialogue);
    }
}
