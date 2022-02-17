using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelUpSceneManager : MonoBehaviour
{
    [Header ("Selected state")]
    [SerializeField] private DataStorage dataStorage;
    private int activeLevels;
    private bool lockedLevel;

    [Header ("Player settings")]
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        activeLevels = dataStorage.levelsUnlocked;
        player.transform.position = spawn.position;
    }
}
