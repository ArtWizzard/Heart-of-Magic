using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private DataStorage storage;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Slider sliderEffects;
    [SerializeField] private Slider sliderDialogues;

    private void Awake()
    {
        if (!storage.started)
        {
            RestartGame();
            storage.started = true;
        }
        sliderVolume.value = storage.volume;
        sliderEffects.value = storage.effects;
        sliderDialogues.value = storage.dialogues;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void SetVolume()
    {
        storage.volume = sliderVolume.value;
    }

    public void SetEffects()
    {
        storage.effects = sliderEffects.value;
    }

    public void SetDialogues()
    {
        storage.dialogues = sliderDialogues.value;
    }

    public void RestartGame()
    {
        // inventory
        storage.runesAmmount = 0;
        storage.keysAmmount = 0;

        // progress
        storage.levelsUnlocked = 0;         // unlocking
        storage.energyUnlocked = false;
        storage.earthUnlocked = false;
        storage.barrierUnlocked = false;
        storage.beamUnlocked = false;

        // player capability
        storage.healthLevel = 1;            // level
        storage.manaLevel = 1;
        storage.healthRegenLevel = 1;
        storage.regenLevel = 1;

        storage.healthCost = 2;             // rune cost
        storage.manaCost = 2;
        storage.healthRegenCost = 2;
        storage.regenCost = 2;

        storage.maxHealth = 100;            // strength
        storage.maxMana = 50;
        storage.healthRegen = 1f;
        storage.manaRegen = 5;

        // magic damage
        storage.energyBallDamage = 5;       // damage
        storage.earthBallDamage = 2;
        storage.barrierDuration = 0.5f;
        storage.beamDamage = 30; 

        storage.energyCost = 1;             // rune cost
        storage.earthCost = 2;
        storage.barrierCost = 3;
        storage.beamCost = 4;

        storage.energyLevel = 1;            // level
        storage.earthLevel = 1;
        storage.barrierLevel = 1;
        storage.beamLevel = 1;
    }
}
