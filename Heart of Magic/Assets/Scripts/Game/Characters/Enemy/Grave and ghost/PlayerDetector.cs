using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    //private bool playerInRagne = false;
    [SerializeField] private GameObject grave;

    private void OnTriggerExit2D(Collider2D collision) 
     {
        if (collision.tag == "Player")
            //playerInRagne = false;
            grave.GetComponent<Grave>().playerInRagne = false;
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            //playerInRagne = true;
            grave.GetComponent<Grave>().playerInRagne = true;
    }
}
