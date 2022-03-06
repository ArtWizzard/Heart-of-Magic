using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private DataStorage storage;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        if (!storage.started)
        {
            RestartGame();
            storage.started = true;
        }
        slider.value = storage.volume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void SetVolume()
    {
        storage.volume = slider.value;
    }

    public void RestartGame()
    {
        // inventory
        storage.runesAmmount = 0;
        storage.keysAmmount = 0;

        // progress
        storage.levelsUnlocked = 0;
        storage.energyUnlocked = false;
        storage.earthUnlocked = false;
        storage.barrierUnlocked = false;
        storage.beamUnlocked = false;

        // player capability
        storage.healthLevel = 1;
        storage.manaLevel = 1;
        storage.healthRegenLevel = 1;
        storage.regenLevel = 1;

        storage.healthCost = 2;
        storage.manaCost = 2;
        storage.healthRegenCost = 2;
        storage.regenCost = 2;

        storage.maxHealth = 100;
        storage.maxMana = 50;
        storage.healthRegen = 0.5f;
        storage.manaRegen = 5;

        // magic damage
        storage.energyBallDamage = 5;
        storage.earthBallDamage = 1;
        storage.barrierDuration = 0.3f;
        storage.beamDamage = 30; 

        storage.energyCost = 1;
        storage.earthCost = 2;
        storage.barrierCost = 3;
        storage.beamCost = 4;

        storage.energyLevel = 1;
        storage.earthLevel = 1;
        storage.barrierLevel = 1;
        storage.beamLevel = 1;
    }
}
