using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Visualization")]
    public Text runeText;
    public int runes = 0;
    public Text keyText;
    public int keys = 0;

    [Header("Storages")]
    [SerializeField] private DataStorage dataStorage;

    private void Awake()
    {
        Actualize();
        /*
        runes = dataStorage.runesAmmount;
        keys = dataStorage.keysAmmount;
        runeText.text = runes.ToString() + "X";
        keyText.text = keys.ToString() + "X";
        */
    }

    public void Actualize()
    {
        runes = dataStorage.runesAmmount;
        keys = dataStorage.keysAmmount;
        runeText.text = runes.ToString() + "X";
        keyText.text = keys.ToString() + "X";
    }

    public void Pick(string type, int _ammount)
    {
        switch(type)
        {
            case "Key":
                keys += _ammount;
                keyText.text = keys.ToString() + "X";
                break;
            case "Rune":
                runes += _ammount;
                runeText.text = runes.ToString() + "X";
                
                dataStorage.runesAmmount += _ammount;

                break;
            default:
                Debug.Log("Wrong item name");
                break;
        }
    }
}
