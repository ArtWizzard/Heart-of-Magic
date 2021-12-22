using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void Select(string _levelName)
    {
        SceneManager.LoadScene(_levelName);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
