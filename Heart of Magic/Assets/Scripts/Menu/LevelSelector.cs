using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelector : MonoBehaviour
{
    [Header ("Levels holder")]
    [SerializeField] private GameObject[] levels;

    [Header ("Selected state")]
    public string levelName = "Menu";
    [SerializeField] private DataStorage dataStorage;
    private int activeLevels;
    private bool lockedLevel;

    private void Awake()
    {
        activeLevels = dataStorage.levelsUnlocked;
    }

    private void Update()
    {
        if (Input.inputString == " ")       // Výběr kola
        {
            if (!lockedLevel)               // odemčen
                LoadLevel(levelName);
        }
    }

    public void Select(string _levelName, bool _locked)
    {
        levelName = _levelName;
        lockedLevel = _locked;

        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].GetComponent<Level_controller>().Change(levelName);
        }
    }

    public void LoadLevel(string _name)
    {
        SceneManager.LoadScene(_name);
    }
}
