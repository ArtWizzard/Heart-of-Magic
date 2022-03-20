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

    [Header ("Check Difficulty")]
    [SerializeField] private Toggle easy;
    [SerializeField] private Toggle medium;
    [SerializeField] private Toggle hard;

    //toggle.isOn

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("gameStarted"))
        {
            PlayerPrefs.SetInt("gameStarted", 1);
            RestartGame();
            SaveGame();
            //Debug.Log("start");
        }
            
        
        sliderVolume.value = storage.volume;
        sliderEffects.value = storage.effects;
        sliderDialogues.value = storage.dialogues;

        SetToggle(storage.difficulty);
        
    }

    private void SetToggle(int _specific)
    {
        easy.SetIsOnWithoutNotify(false);
        medium.SetIsOnWithoutNotify(false);
        hard.SetIsOnWithoutNotify(false);

        switch(_specific)
        {
            case 1:
                easy.SetIsOnWithoutNotify(true);
                break;
            case 2:
                medium.SetIsOnWithoutNotify(true);
                break;
            case 3:
                hard.SetIsOnWithoutNotify(true);
                break;
        }
    }

    public void PlayGame()
    {
        LoadGame();
        SceneManager.LoadScene("LevelSelect");
    }

    public void SetVolume()
    {
        storage.volume = sliderVolume.value;
    }

    public void ClickSound()
    {
        SoundManager.PlaySound("click");
    }

    public void SetEffects()
    {
        storage.effects = sliderEffects.value;
    }

    public void SetDialogues()
    {
        storage.dialogues = sliderDialogues.value;
    }

    public void QuitApplication()
    {
        Debug.Log("App has quit");
        Application.Quit();
    }

    public void SetEasy()
    {
        storage.difficulty = 1;
        storage.diffMulti = 0.4f;
        SetToggle(1);
    }

    public void SetMedium()
    {
        storage.difficulty = 2;
        storage.diffMulti = 0.7f;
        SetToggle(2);
    }

    public void SetHard()
    {
        storage.difficulty = 3;
        storage.diffMulti = 1f;
        SetToggle(3);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("runesAmmount", storage.runesAmmount);
        PlayerPrefs.SetInt("keysAmmount", storage.keysAmmount);

        PlayerPrefs.SetInt("levelsUnlocked", storage.levelsUnlocked);

        PlayerPrefs.SetInt("energyUnlocked", BoolToInt(storage.energyUnlocked));
        PlayerPrefs.SetInt("earthUnlocked", BoolToInt(storage.earthUnlocked));
        PlayerPrefs.SetInt("barrierUnlocked", BoolToInt(storage.barrierUnlocked));
        PlayerPrefs.SetInt("beamUnlocked", BoolToInt(storage.beamUnlocked));

        // player capability
        PlayerPrefs.SetInt("healthLevel", storage.healthLevel);
        PlayerPrefs.SetInt("manaLevel", storage.manaLevel);
        PlayerPrefs.SetInt("healthRegenLevel", storage.healthRegenLevel);
        PlayerPrefs.SetInt("regenLevel", storage.regenLevel);

        PlayerPrefs.SetInt("healthCost", storage.healthCost);
        PlayerPrefs.SetInt("manaCost", storage.manaCost);
        PlayerPrefs.SetInt("healthRegenCost", storage.healthRegenCost);
        PlayerPrefs.SetInt("regenCost", storage.regenCost);

        PlayerPrefs.SetInt("maxHealth", storage.maxHealth);
        PlayerPrefs.SetInt("maxMana", storage.maxMana);
        PlayerPrefs.SetFloat("healthRegen", storage.healthRegen);
        PlayerPrefs.SetFloat("manaRegen", storage.manaRegen);

        // magic damage
        PlayerPrefs.SetInt("energyBallDamage", storage.energyBallDamage);
        PlayerPrefs.SetInt("earthBallDamage", storage.earthBallDamage);
        PlayerPrefs.SetFloat("barrierDuration", storage.barrierDuration);
        PlayerPrefs.SetInt("beamDamage", storage.beamDamage);

        PlayerPrefs.SetInt("energyCost", storage.energyCost);
        PlayerPrefs.SetInt("earthCost", storage.earthCost);
        PlayerPrefs.SetInt("barrierCost", storage.barrierCost);
        PlayerPrefs.SetInt("beamCost", storage.beamCost);

        PlayerPrefs.SetInt("energyLevel", storage.energyLevel);
        PlayerPrefs.SetInt("earthLevel", storage.earthLevel);
        PlayerPrefs.SetInt("barrierLevel", storage.barrierLevel);
        PlayerPrefs.SetInt("beamLevel", storage.beamLevel);

        PlayerPrefs.SetInt("difficulty", storage.difficulty);
        PlayerPrefs.SetFloat("diffMulti", storage.diffMulti);
    }

    public void LoadGame()
    {
        storage.runesAmmount = PlayerPrefs.GetInt("runesAmmount");
        storage.keysAmmount = PlayerPrefs.GetInt("keysAmmount");

        storage.levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked");

        storage.energyUnlocked = IntToBool(PlayerPrefs.GetInt("energyUnlocked"));
        storage.earthUnlocked = IntToBool(PlayerPrefs.GetInt("earthUnlocked"));
        storage.barrierUnlocked = IntToBool(PlayerPrefs.GetInt("barrierUnlocked"));
        storage.beamUnlocked = IntToBool(PlayerPrefs.GetInt("beamUnlocked"));

        // player capability
        storage.healthLevel = PlayerPrefs.GetInt("healthLevel");
        storage.manaLevel = PlayerPrefs.GetInt("manaLevel");
        storage.healthRegenLevel = PlayerPrefs.GetInt("healthRegenLevel");
        storage.regenLevel = PlayerPrefs.GetInt("regenLevel");

        storage.healthCost = PlayerPrefs.GetInt("healthCost");
        storage.manaCost = PlayerPrefs.GetInt("manaCost");
        storage.healthRegenCost = PlayerPrefs.GetInt("healthRegenCost");
        storage.regenCost = PlayerPrefs.GetInt("regenCost");

        storage.maxHealth = PlayerPrefs.GetInt("maxHealth");
        storage.maxMana = PlayerPrefs.GetInt("maxMana");
        storage.healthRegen = PlayerPrefs.GetFloat("healthRegen");
        storage.manaRegen = PlayerPrefs.GetFloat("manaRegen");

        // magic damage
        storage.energyBallDamage = PlayerPrefs.GetInt("energyBallDamage");
        storage.earthBallDamage = PlayerPrefs.GetInt("earthBallDamage");
        storage.barrierDuration = PlayerPrefs.GetFloat("barrierDuration");
        storage.beamDamage = PlayerPrefs.GetInt("beamDamage");

        storage.energyCost = PlayerPrefs.GetInt("energyCost");
        storage.earthCost = PlayerPrefs.GetInt("earthCost");
        storage.barrierCost = PlayerPrefs.GetInt("barrierCost");
        storage.beamCost = PlayerPrefs.GetInt("beamCost");

        storage.energyLevel = PlayerPrefs.GetInt("energyLevel");
        storage.earthLevel = PlayerPrefs.GetInt("earthLevel");
        storage.barrierLevel = PlayerPrefs.GetInt("barrierLevel");
        storage.beamLevel = PlayerPrefs.GetInt("beamLevel");

        storage.difficulty = PlayerPrefs.GetInt("difficulty");
        storage.diffMulti = PlayerPrefs.GetFloat("diffMulti");
    }

    private int BoolToInt(bool _bool)
    {
        if (_bool)
            return 1;
        else
            return 0;
    }

    private bool IntToBool(int _int)
    {
        if (_int != 0)
            return true;
        else
            return false;
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
        storage.healthRegen = 3f;
        storage.manaRegen = 11;

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

        // settings
        storage.difficulty = 2;
        storage.diffMulti = 0.7f;
    }
}
