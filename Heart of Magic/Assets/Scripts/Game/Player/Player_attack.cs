using UnityEngine;
using System.Collections.Generic;

public class Player_attack : MonoBehaviour
{
    [Header ("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float magicDelay;
    [Header ("Magic objects")]
    [SerializeField] private GameObject[] energyballs;
    [SerializeField] private GameObject[] bombsartilery;
    [SerializeField] private GameObject[] barriers;

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
    }

    private void Update()
    { 
        if( cooldownTimer >= attackCooldown && 0 <= FindEnergyballs() && BombsExploded() && !FindObjectOfType<Player_movement>().isMoving() && !(energy || bomb))
        {
            switch (Input.inputString)
            {
                case "5":
                    SetAttack();
                    energy = true;
                    break;

                case "8":
                    //Artilery();
                    SetAttack();
                    bomb = true;
                    break;
                case "2":
                    SetAttack();
                    barrier = true;
                    break;
            }
        }
        cooldownTimer += Time.deltaTime;
        
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
        }

    }

    private void SetAttack()
    {
        DelayTimer = 0;
        anim.SetTrigger("attack");
    }

//------------------------------Energy ball
    private void Attack()
    {
        cooldownTimer = 0;
        energy = false;
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
        bomb = false;

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
        barrier = false;
        //Set barrier
        barriers[0].GetComponent<Barrier>().SetBarrier();
    }
} // -------------------------- closing class