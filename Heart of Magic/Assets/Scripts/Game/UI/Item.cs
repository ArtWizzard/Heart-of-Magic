using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // some pleb
    public enum InteractionType {Key, Rune};
    //  public InteractionType type;
    [Header("Manager")]
    [SerializeField] public InventoryManager IM;
    [Header("Properities")]
    [SerializeField] private int value;
    private CircleCollider2D CircleCollider;
    private bool taken = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !taken)
        {
            //Destroy(gameObject);
            taken = true;
            //Debug.Log("now");
            IM.PickRune(value);
            gameObject.SetActive(false);
        }
    }


}
