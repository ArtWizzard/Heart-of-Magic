using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Visualization")]
    public Text runeText;
    public int runes = 0;

    private void Awake()
    {
        runeText.text = runes.ToString() + "X";
    }

    public void PickRune(int _ammount)
    {
        runes += _ammount;
        runeText.text = runes.ToString() + "X";
        //Debug.Log(runes);
    }
}
