using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum atributName{
    EnergyBall,
    EarthBall,
    Beam,
    Barrier
};

public class Pillar_controller : MonoBehaviour
{

    Dictionary<atributName, int> translation = new Dictionary<atributName, int>(){
        {atributName.EnergyBall, 0},
        {atributName.EarthBall, 1},
        {atributName.Beam, 2},
        {atributName.Barrier, 3},
    };

    [Header ("Appearance")]
    [SerializeField] private Sprite def;
    [SerializeField] private Sprite selected;
    private GameObject child;

    [Header ("Storage")]
    [SerializeField] private DataStorage dataStorage;
    [SerializeField] private atributName atribut;
    private bool active = false;

    [Header ("Parameters")]
    [SerializeField] private int rAN;                   //  runeAmmountNeeded
    [SerializeField] private float upgrade;

    private bool inside = false;

    private SpriteRenderer pic;

    private void Awake()
    {
        child = transform.GetChild(0).gameObject;
        pic = GetComponent<SpriteRenderer>();
        pic.sprite = def;

        switch(translation[atribut])
        {
            case 0:
                if (dataStorage.energyUnlocked)
                    active = true;
                break;
            case 1:
                if (dataStorage.earthUnlocked)
                    active = true;
                break;
            case 2:
            if (dataStorage.barrierUnlocked)
                    active = true;
                break;
            case 3:
            if (dataStorage.beamUnlocked)
                    active = true;
                break;
        }
        if (active)
            child.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inside)
        {
            if(rAN <= dataStorage.runesAmmount && active)
            {
                dataStorage.runesAmmount -= rAN;
                switch(atribut)
                {
                    case atributName.EnergyBall:    //  int
                        dataStorage.energyBallDamage    += (int)upgrade;   
                        break;
                    case atributName.EarthBall:    //  int
                        dataStorage.earthBallDamage    += (int)upgrade;      
                        break;
                    case atributName.Beam:          //  int
                        dataStorage.beamDamage          += (int)upgrade; 
                        break;
                    case atributName.Barrier:       //  float
                        dataStorage.barrierDuration     += upgrade; 
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pic.sprite = selected;
        inside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pic.sprite = def;
        inside = false;
    }
}
