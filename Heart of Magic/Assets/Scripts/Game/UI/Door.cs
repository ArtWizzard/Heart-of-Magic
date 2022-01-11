using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] public InventoryManager IM;

    [Header("Door")]
    [SerializeField] public GameObject doors;

    [Header("Properities")]
    [SerializeField] private int keys_needed;

    private bool open = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int keyAmmount = IM.GetComponent<InventoryManager>().keys;

        if(collision.tag == "Player" && keyAmmount - keys_needed >= 0  && !open)
        {
            IM.Pick("Key", -keys_needed);
            doors.SetActive(false);
            open = true;
        }
    }
}
