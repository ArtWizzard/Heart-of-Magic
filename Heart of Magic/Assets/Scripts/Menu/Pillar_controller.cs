using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum atributName{
    EnergyBall,
    EarthBall,
    Barrier,
    Beam,
    Health,
    Health_regen,
    Mana,
    Mana_regen
};

public class Pillar_controller : MonoBehaviour
{
    private const int ENERGY = 0;
    private const int EARTH = 1;
    private const int BARRIER = 2;
    private const int BEAM = 3;
    private const int HEALTH = 4;
    private const int HEALTH_R = 5;
    private const int MANA = 6;
    private const int MANA_R = 7;

    Dictionary<atributName, int> translation = new Dictionary<atributName, int>(){
        {atributName.EnergyBall, ENERGY},
        {atributName.EarthBall, EARTH},
        {atributName.Barrier, BARRIER},
        {atributName.Beam, BEAM},
        {atributName.Health, HEALTH},
        {atributName.Health_regen, HEALTH_R},
        {atributName.Mana, MANA},
        {atributName.Mana_regen, MANA_R},
    };

    [Header ("Level steps")]
    [SerializeField] private float energyStep =     4.0f;
    [SerializeField] private float earthStep =      3.0f;
    [SerializeField] private float barrierStep =    0.1f;
    [SerializeField] private float beamStep =       10.0f;
    [SerializeField] private float healthStep =     20.0f;
    [SerializeField] private float healthRStep =    1f;
    [SerializeField] private float manaStep =       10.0f;
    [SerializeField] private float manaRStep =      0.5f;

    [Header ("Appearance")]
    [SerializeField] private Sprite def;
    [SerializeField] private Sprite selected;
    private GameObject child;
    private GameObject childInfo;

    [Header ("Storage")]
    [SerializeField] private DataStorage dataStorage;
    [SerializeField] private atributName atribut;
    private bool active = false;

    [Header ("Parameters")]
    [SerializeField] private int rAN;                   //  runeAmmountNeeded
    private float upgrade; //[SerializeField] 
    private int level;
    private float power;

    private bool inside = false;

    private SpriteRenderer pic;

    private void Awake()
    {
        child = transform.GetChild(0).gameObject;
        childInfo = transform.GetChild(1).gameObject;
        //Debug.Log(childInfo.name);
        pic = GetComponent<SpriteRenderer>();
        pic.sprite = def;

        Actualize();

        if (active)
            child.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inside)
        {
            if(rAN <= dataStorage.runesAmmount && active && level < 10)
            {
                SoundManager.PlaySound("upgrade");
                switch(atribut)
                {
                    case atributName.EnergyBall:        //  int
                        dataStorage.energyBallDamage    += (int)energyStep; //(int)upgrade;   
                        dataStorage.energyLevel ++;
                        break;
                    case atributName.EarthBall:         //  int
                        dataStorage.earthBallDamage    += (int)earthStep; //(int)upgrade;  
                        dataStorage.earthLevel ++;    
                        break;
                    case atributName.Barrier:           //  int
                        dataStorage.barrierDuration     += barrierStep; //upgrade; 
                        dataStorage.barrierLevel ++;
                        break;
                    case atributName.Beam:              //  float
                        dataStorage.beamDamage          += (int)beamStep; //(int)upgrade; 
                        dataStorage.beamLevel ++;
                        break;
                    case atributName.Health:            //  int
                        dataStorage.maxHealth           += (int)healthStep; //(int)upgrade; 
                        dataStorage.healthLevel ++;
                        break;
                    case atributName.Health_regen:       //  float
                        dataStorage.healthRegen         += healthRStep; //upgrade; 
                        dataStorage.healthRegenLevel ++;
                        break;
                    case atributName.Mana:              //  int
                        dataStorage.maxMana             += (int)manaStep; //(int)upgrade; 
                        dataStorage.manaLevel ++;
                        break;
                    case atributName.Mana_regen:        //  float
                        dataStorage.manaRegen           += manaRStep; //upgrade; 
                        dataStorage.regenLevel ++;
                        break;
                }
                dataStorage.runesAmmount -= rAN;
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().Actualize();
            }
            Actualize();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Actualize();
        SoundManager.PlaySound("choose");

        if (active)
        {
            pic.sprite = selected;
            inside = true;
            childInfo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (active)
        {
            pic.sprite = def;
            inside = false;
            childInfo.SetActive(false);
        }
    }

    private void Actualize()
    {
        switch(translation[atribut])
        {
            case ENERGY:
                level = dataStorage.energyLevel;
                power = dataStorage.energyBallDamage;
                upgrade = energyStep;
                rAN = level * dataStorage.energyCost; // dataStorage.energyCost + 
                if (dataStorage.energyUnlocked)
                    active = true;

                break;
            case EARTH:
                level = dataStorage.earthLevel;
                power = dataStorage.earthBallDamage;
                upgrade = earthStep;
                rAN = level * dataStorage.earthCost; // dataStorage.earthCost + 
                if (dataStorage.earthUnlocked)
                    active = true;

                break;
            case BARRIER:
                level = dataStorage.barrierLevel;
                power = dataStorage.barrierDuration;
                upgrade = barrierStep;
                rAN = level * dataStorage.barrierCost; // dataStorage.barrierCost + 
                if (dataStorage.barrierUnlocked)
                    active = true;

                break;
            case BEAM:
                level = dataStorage.beamLevel;
                power = dataStorage.beamDamage;
                upgrade = beamStep;
                rAN = level * dataStorage.beamCost; // dataStorage.beamCost + 
                if (dataStorage.beamUnlocked)
                    active = true;
                
                break;
            case HEALTH:
                level = dataStorage.healthLevel;
                power = dataStorage.maxHealth;
                upgrade = healthStep;
                rAN = level * dataStorage.healthCost; // dataStorage.healthCost + 
                active = true;
                
                break;
            case HEALTH_R:
                level = dataStorage.healthRegenLevel;
                power = dataStorage.healthRegen;
                upgrade = healthRStep;
                rAN = level * dataStorage.healthRegenCost; // dataStorage.healthRegenCost + 
                active = true;
                
                break;
            case MANA:
                level = dataStorage.manaLevel;
                power = dataStorage.maxMana;
                upgrade = manaStep;
                rAN = level * dataStorage.manaCost; // dataStorage.manaCost + 
                active = true;
                
                break;
            case MANA_R:
                level = dataStorage.regenLevel;
                power = dataStorage.manaRegen;
                upgrade = manaRStep;
                rAN = level * dataStorage.regenCost; // dataStorage.regenCost + 
                active = true;
                
                break;
        }
        childInfo.GetComponent<LevelUp_info>().SetInfo(rAN, upgrade, translation[atribut], power, level);
    }
}
