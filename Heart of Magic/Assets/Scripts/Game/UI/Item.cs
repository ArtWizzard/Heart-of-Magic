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
    [SerializeField] public int value;
    private CircleCollider2D CircleCollider;
    private bool taken = false;
    private string item_type;

    [Header("Droprate [%]")]
    [SerializeField] private int dRate = 0;
    private int reduced = 1;    //  1 - normální drop-rate, 2 - poloviční drop-rate
    
    [Header("Storages")]
    [SerializeField] private DataStorage dataStorage;
    private bool lvlCleared;
    
    public enum ItemType{
        Key,
        Rune
    }
 
    private void Awake()
    {
        lvlCleared = GameObject.Find("LevelManager").GetComponent<LevelManager>().currentLevel < dataStorage.levelsUnlocked;
        //  Random.Range(0,10);     //  int from 0 to 9
        if(lvlCleared)
            reduced = 2;

        if(Random.Range(0,100)*reduced >= dRate)
            gameObject.SetActive(false);

        if (IM == null)
        {
            IM = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        }
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
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }


}
