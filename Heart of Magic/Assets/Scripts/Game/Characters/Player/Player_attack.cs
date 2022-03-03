using UnityEngine;
using System.Collections.Generic;

public class Player_attack : MonoBehaviour
{
    [Header ("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float magicDelay;
    [Header ("Mana management")]
    [SerializeField] private Mana_bar mana_controller;
    [SerializeField] private int energyCost;
    [SerializeField] private int earthCost;
    [SerializeField] private int barrierCost;
    [SerializeField] private int beamCost;
    [Header ("Magic objects")]
    [SerializeField] private GameObject[] energyballs;
    [SerializeField] private GameObject[] bombsartilery;
    [SerializeField] private GameObject[] barriers;
    [SerializeField] private GameObject[] beams;
    [SerializeField] private float deltaYBeam;
    [SerializeField] private float deltaXBeam;
    [Header ("Data storage")]
    [SerializeField] private DataStorage storage;

    private Animator anim;
    private Player_movement playerMovement;
    //  Counters
    private float cooldownTimer = Mathf.Infinity;
    private float DelayTimer = Mathf.Infinity;
    //  Data package
    private bool energy;
    private bool bomb;
    private bool barrier;
    //private Dictionary<string, int> magic;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Player_movement>();

        energy = false;
        bomb = false;
        barrier = false;

        if (mana_controller == null)
        {
            mana_controller = GameObject.Find("Mana_bar").GetComponent<Mana_bar>();
        }
    }

    private void Update()
    { 
        if( cooldownTimer >= attackCooldown && 0 <= FindEnergyballs() && BombsExploded() && !FindObjectOfType<Player_movement>().isMoving() && !(energy || bomb))
        {
            switch (Input.inputString)
            {
                case "q":
                    if (SetAttack(energyCost, storage.energyUnlocked))
                        Attack();
                    break;
                case "w":
                    if (SetAttack(earthCost, storage.earthUnlocked))
                        Artilery();
                    break;
                case "e":
                    if (SetAttack(barrierCost, storage.barrierUnlocked))
                        SetBarrier();
                    break;
                case "r":
                    if (SetAttack(beamCost, storage.beamUnlocked))
                        SetBeam();
                    break;
            }
        }
        cooldownTimer += Time.deltaTime;
        /*
        if(DelayTimer > magicDelay)
        {
            if(energy)
                Attack();
            if(bomb)
                Artilery();
            if(barrier)
                SetBarrier();
        }
        else
        {
            DelayTimer += Time.deltaTime;
        }*/

    }

    private bool SetAttack(int _cost, bool _active)
    {
        if (_active)
        {
            bool enoughMana = mana_controller.SpendMana(_cost);
            if (enoughMana)
            {
                anim.SetTrigger("attack");
                return true;
            } else
                return false;
        } else
            return false;
    }

//------------------------------Energy ball
    private void Attack()
    {
        cooldownTimer = 0;
        //energy = false;
        //Pool fireballs
        energyballs[FindEnergyballs()].transform.position = firePoint.position;
        energyballs[FindEnergyballs()].GetComponent<Energy_fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    //  Najde nejlepší energyball
    private int FindEnergyballs()
    {
        for(int i = 0; i < energyballs.Length; i++)
        {
            if(!energyballs[i].activeInHierarchy)
                return i;
        }
        return -1;  //  vrať hodnotu zápornou, jestliže nemá žádný volný energyball
    }

//------------------------------Bomb artilery
    private void Artilery()
    {
        cooldownTimer = 0;
        //bomb = false;

        //Bombs inactive
        if(BombsExploded())
        {
            for(int i = 0; i < bombsartilery.Length; i++)
            {
                bombsartilery[i].transform.position = firePoint.position;
                bombsartilery[i].GetComponent<Bomb_artilery>().SetDirection(Mathf.Sign(transform.localScale.x));
            }
        }
    }

    //  same
    private bool BombsExploded()
    {
        for(int i = 0; i < bombsartilery.Length; i++)
        {
            if(bombsartilery[i].activeInHierarchy)
                return false;
        }
        return true;  //  vrať hodnotu zápornou, jestliže nemá žádný volný energyball
    }

//------------------------------Barrier
    private void SetBarrier()
    {
        cooldownTimer = 0;
        //barrier = false;
        //Set barrier
        barriers[0].GetComponent<Barrier>().SetBarrier();
    }
//------------------------------Beam
    private void SetBeam()
    {
        cooldownTimer = 0;
        beams[0].transform.localScale = transform.localScale; //new Vector3(-1, 1, 1);
        
        Vector3 beamDir;
        if(transform.localScale.x < 0)
            beamDir = new Vector3(firePoint.position.x - deltaXBeam, firePoint.position.y + deltaYBeam, firePoint.position.z);
        else
            beamDir = new Vector3(firePoint.position.x + deltaXBeam, firePoint.position.y + deltaYBeam, firePoint.position.z);

        beams[0].transform.position = beamDir;
        beams[0].GetComponent<Beam>().Shoot();
    }
} // -------------------------- closing class