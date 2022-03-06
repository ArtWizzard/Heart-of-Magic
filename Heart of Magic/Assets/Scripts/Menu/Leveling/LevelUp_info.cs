using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp_info : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private GameObject info;
    [SerializeField] private Text infoText;
    private const int ENERGY = 0;
    private const int EARTH = 1;
    private const int BARRIER = 2;
    private const int BEAM = 3;
    private const int HEALTH = 4;
    private const int HEALTH_R = 5;
    private const int MANA = 6;
    private const int MANA_R = 7;

    [Header ("Position")]
    [SerializeField] private Vector3 Offset;  // Pozice healthBaru

    void Update()
    {
        info.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    public void SetInfo(int _runes, float _upgrade, int _type, float _power, int _level)
    {
        string type_power;
        string type_cost;
        string type_upgrade;

        if (_level < 10)
        {
            type_cost = _runes + "";
            type_upgrade = " + " + _upgrade.ToString();
        }
        else
        {
            type_cost = "-";
            type_upgrade = "";
        }

        if (_type == BARRIER)
            type_power = "Duration: ";
            
        else if (_type == ENERGY || _type == EARTH || _type == BEAM)
            type_power = "Power: ";
        else if (_type == MANA)
            type_power = "Max mana: ";
        else if (_type == HEALTH)
            type_power = "Max health: ";
        else if (_type == MANA_R)
            type_power = "Mana regen: ";
        else if (_type == HEALTH_R)
            type_power = "Health regen: ";
        else
            type_power = "";

        infoText.text = "Level " + _level + "\n" +
                        "Runes: " + type_cost + "\n" + 
                        type_power + _power + type_upgrade;
    }
}
