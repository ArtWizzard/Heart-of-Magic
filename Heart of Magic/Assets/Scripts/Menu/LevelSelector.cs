using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelector : MonoBehaviour
{
    [Header ("Selected state")]
    [SerializeField] private DataStorage dataStorage;

    [Header ("Player settings")]
    [SerializeField] private Transform spawn;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        player.transform.position = spawn.position;
    }
}
