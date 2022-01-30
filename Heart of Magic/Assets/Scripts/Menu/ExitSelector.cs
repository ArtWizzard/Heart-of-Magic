using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSelector : MonoBehaviour
{
    [SerializeField] private GameObject manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.GetComponent<LevelSelector>().LoadLevel("Menu");
    }
}
