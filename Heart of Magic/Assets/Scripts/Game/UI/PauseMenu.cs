using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;        //  freeze the game
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        if (GameObject.Find("InventoryManager") != null)
            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().Tax();
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        if (GameObject.Find("InventoryManager") != null)
            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().Tax();
        SceneManager.LoadScene("LevelSelect");
    }
}
