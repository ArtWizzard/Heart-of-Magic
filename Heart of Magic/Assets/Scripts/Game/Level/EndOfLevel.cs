using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    [Header ("Informations")]
    [SerializeField] private int currentLevel;

    [Header ("Storage to update")]
    [SerializeField] private DataStorage dataStorage;
    private int activeLevels;

    private void Awake()
    {
        activeLevels = dataStorage.levelsUnlocked;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.tag == "Player")
        if (activeLevels <= currentLevel)
        {
            dataStorage.levelsUnlocked = currentLevel + 1;
        }
        FindObjectOfType<LevelManager>().Exit();
    }
}
