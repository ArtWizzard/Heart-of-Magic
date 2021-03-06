using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;
    public static LevelManager instance;

    [Header ("Informations")]
    public int currentLevel;

    private void Awake()
    {
        Respawn();
        instance = this;
        player.transform.position = respawnPoint.position;      //  přemístí ho na respawn
    }

    public void Respawn()
    {
        //Debug.Log("Respawn");
        player.SetActive(false);                                //  zničí hráče
        player.transform.position = respawnPoint.position;      //  přemístí ho na respawn
        player.SetActive(true);                                 //  vytvoří hráče
        FindObjectOfType<Player_health>().ResetHealth();        //  má plné životy
    }

    public void Exit()
    {
        SceneManager.LoadScene("LevelSelect");  //  Vyjde z levlu do výběru kol
    }

}
