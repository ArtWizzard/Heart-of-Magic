using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //  public InteractionType type;
    [Header("Manager")]
    [SerializeField] public InventoryManager IM;
    [Header("Properities")]
    [SerializeField] private ItemType type;
    [SerializeField] private int value;
    private CircleCollider2D CircleCollider;
    private bool taken = false;
    private string item_type;

    public enum ItemType{
        Key,
        Rune
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !taken)
        {
            taken = true;
            if(type == ItemType.Key)
                item_type = "Key";
            else if(type == ItemType.Rune)
                item_type = "Rune";

            IM.Pick(item_type, value);
            gameObject.SetActive(false);
        }
    }


}
