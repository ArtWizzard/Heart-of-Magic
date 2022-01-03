using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum InteractionType {Key, Rune};
    //  public InteractionType type;
    private BoxCollider2D BoxCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<InventoryManager>().PickRune();
        }
    }
}
