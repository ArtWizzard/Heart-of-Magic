using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk_controller : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    private bool isIn;

    private void Update()
    {
        if (isIn && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Talk");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isIn = true;
        hint.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
        hint.SetActive(false);
    }
}
