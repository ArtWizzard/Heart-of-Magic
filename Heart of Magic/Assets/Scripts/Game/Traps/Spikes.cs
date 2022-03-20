using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private int currentLevel;
    private LevelManager LM;

    [Header ("Data storage")]
    [SerializeField] private DataStorage storage;

    private void Awake()
    {
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //currentLevel = GameObject.Find("LevelManager").GetComponent<LevelManager>().currentLevel;
            //collision.GetComponent<Player_health>().Kill();
            //SceneManager.LoadScene("Level_" + currentLevel);

            int max = collision.GetComponent<Player_health>().maxHealth;
            collision.GetComponent<Player_health>().TakeDamage((int)((max / 3) * storage.diffMulti));
        }
    }
}
