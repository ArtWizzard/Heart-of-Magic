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

    private void OnDisable()
    {
        ItemDrop();
    }

    public void ItemDrop()
    {
        pos = new Vector3(transform.position.x, transform.position.y + yDelta, transform.position.z);

        if(Random.Range(0,100) <= dropRate)
        {
            if (type == item.key)
            {
                Instantiate(key, pos, Quaternion.identity);
            } 
            else if (type == item.rune)
            {
                Instantiate(rune, pos, Quaternion.identity);
            }
        }
    }
}
