using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum atributName{
    EnergyBall,
    EarthyBall,
    Beam,
    Barrier
};

public class Pillar_controller : MonoBehaviour
{

    Dictionary<atributName, int> translation = new Dictionary<atributName, int>(){
        {atributName.EnergyBall, 0},
        {atributName.EarthyBall, 1},
        {atributName.Beam, 2},
        {atributName.Barrier, 3},
    };

    [Header ("Appearance")]
    [SerializeField] private Sprite def;
    [SerializeField] private Sprite selected;
    [SerializeField] private Animator child;

    [Header ("Storage")]
    [SerializeField] private DataStorage dataStorage;
    [SerializeField] private atributName atribut;

    [Header ("Parameters")]
    [SerializeField] private int rAN;                   //  runeAmmountNeeded
    [SerializeField] private float upgrade;

    private bool inside = false;

    private SpriteRenderer pic;

    private void Awake()
    {
        pic = GetComponent<SpriteRenderer>();
        pic.sprite = def;
        child.SetInteger("atribut", translation[atribut]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inside)
        {
            if(rAN <= dataStorage.runesAmmount)
            {
                dataStorage.runesAmmount -= rAN;
                switch(atribut)
                {
                    case atributName.EnergyBall:    //  int
                        dataStorage.energyBallDamage    += (int)upgrade;   
                        break;
                    case atributName.EarthyBall:    //  int
                        dataStorage.energyBallDamage    += (int)upgrade;      
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
