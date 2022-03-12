using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum item{
    key,
    rune
};

public class Item_drop_controller : MonoBehaviour
{
    [Header ("Select")]
    public item type;
    [Header ("Droprate [%]")]
    [SerializeField] private int dropRate = 0;
    [SerializeField] private float yDelta = 0.5f;
    private Vector3 pos;
    [Header ("Items")]
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject rune;
    [SerializeField] private int ammount = 1;

    public GameObject loot;


    private void Throw()
    {
        ItemDrop();
    }

    public void ItemDrop()
    {
        pos = new Vector3(transform.position.x, transform.position.y + yDelta, transform.position.z);
        
        bool dropping = Random.Range(0,100) <= dropRate;
        Debug.Log(dropping);

        if(dropping)
        {
            if (type == item.key)
            {
                loot = Instantiate(key, pos, Quaternion.identity);
            } 
            else if (type == item.rune)
            {
                loot = Instantiate(rune, pos, Quaternion.identity);
            }
            loot.SetActive(true);
            loot.GetComponent<Item>().value = ammount;
            //Debug.Log(loot.GetComponent<Item>().value);
            if (ammount >= 10)
                loot.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
            //Debug.Log(loot.name);
            //item.GetComponent<Item>().value = ammount;
        }
    }
}
