using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private int currentLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentLevel = GameObject.Find("LevelManager").GetComponent<LevelManager>().currentLevel;
            //collision.GetComponent<Player_health>().Kill();
            SceneManager.LoadScene("Level_" + currentLevel);
        }
    }
}
