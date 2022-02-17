using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour
{
    [Header ("Scene")]
    [SerializeField] private string target; 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) // snímá stisk jen při doteku do brány
        {
            Debug.Log(target);
            SceneManager.LoadScene(target);
        }
    }
}
