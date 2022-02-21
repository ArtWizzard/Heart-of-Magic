using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private DataStorage storage;

    private void Awake()
    {
        if (!storage.started)
        {
            RestartGame();
            storage.started = true;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
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
        storage.maxHealth = 100;
        storage.maxMana = 50;
        storage.manaRegen = 5;

        // magic damage
        storage.energyBallDamage = 3;
        storage.earthBallDamage = 1;
        storage.barrierDuration = 1;
        storage.beamDamage = 10; 
    }
}
