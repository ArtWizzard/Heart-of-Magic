using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    /*
    [Header ("Informations")]
    public int currentLevel;
    */

    [Header ("Storage to update")]
    [SerializeField] private DataStorage dataStorage;
    private int activeLevels;

    private int currentLevel;

    private void Awake()
    {
        activeLevels = dataStorage.levelsUnlocked;
        currentLevel = gameObject.GetComponentInParent<LevelManager>().currentLevel;
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
