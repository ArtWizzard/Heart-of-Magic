using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    //private bool gameHasEnded = false;
    private Scene scene;
    [SerializeField] GameObject canvas;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        canvas.SetActive(true);
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

    public void Restart()
    {
        Time.timeScale = 1f;
        if (GameObject.Find("InventoryManager") != null)
            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().Tax();
        SceneManager.LoadScene(scene.name);
    }
}
