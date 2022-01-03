using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    /*
    [Header("Detection Parameters")]
    //  Detection point
    public Transform detectionPoint;
    //  Detection radius
    private const float detectionRadius = 0.2f;
    //  Detection layer
    public LayerMask detectionLayer;
    //  Cached Trigger Object
    public GameObject detectObject;
    [Header("Others")]
    //  List of picked items
    public List<GameObject> pickedItems = new List<GameObject>();
    */
    public int runes = 0;

    public void PickRune()
    {
        runes = runes + 1;
    }
}
