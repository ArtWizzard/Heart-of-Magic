using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelector : MonoBehaviour
{
    [Header ("Levels holder")]
    [SerializeField] private GameObject[] levels;

    [Header ("Selected state")]
    public string levelName = "Menu";

    private void Update()
    {
        if (Input.inputString == " ")
        {
            LoadLevel(levelName);
        }
    }

    public void Select(string _levelName)
    {
        levelName = _levelName;

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
