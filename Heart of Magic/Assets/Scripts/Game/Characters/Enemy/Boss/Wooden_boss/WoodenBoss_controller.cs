using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    #  Teleportation
    #  Shooting
        # Missile
        # Projectile
    #  Spawning
        # Ghosts
        # WizGhosts
    #  Spawning seeds
*/

public enum State{
    TP,
    Shoot,
    Evocate,
    Spawn
};

public class WoodenBoss_controller : MonoBehaviour
{
    [Header ("Time")]
    [SerializeField] private float timeDelay;
    [SerializeField] private float hystereze;
    private float actualDelay;

    [Header ("State")]
    private State state;

    private Animator anim;

    private void Awake()
    {
        //state = State.Shoot; // that will be first state
        state = State.TP;
        //state = State.Spawn;
        //state = State.Evocate;
        
        actualDelay  = 0;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ActionDecider();
        //Floating();
    }

    private void ActionDecider()
    {
        if (actualDelay >= timeDelay + Random.Range(-hystereze, hystereze))
        {
            //gameObject.GetComponent<WoodenBoss_movement>().RandomTP();
            switch(state)
            {
                case State.TP:
                    //Debug.Log("randomTP");

                    gameObject.GetComponent<Levitation>().UnsetFloating();
                    anim.SetTrigger("Teleport");
                    SoundManager.PlaySound("tp");
                    RandomAction();
                    break;

                case State.Shoot:
                    //Debug.Log("Shooting");

                    anim.SetBool("Shooting", true);

                    RandomAction();
                    break;

                case State.Evocate:
                    //Debug.Log("Evocate");

                    gameObject.GetComponent<WoodenBoss_evocate>().SetImpact();

                    RandomAction();
                    break;

                case State.Spawn:
                    //Debug.Log("Spawn");

                    gameObject.GetComponent<WoodenBoss_spawn>().SpawnMonsters();

                    RandomAction();
                    break;
            }
            actualDelay = 0;
        }
        actualDelay += Time.deltaTime;
    }

    private void RandomAction()
    {
        bool dodgeEvocation = gameObject.GetComponent<WoodenBoss_evocate>().AnySeedsDefeated();
        bool dodgeSpawn = gameObject.GetComponent<WoodenBoss_spawn>().AnyGhostDefeated();
        


        switch (Random.Range(0,4))
        {
            case 0:
                state = State.TP;
                break;
            case 1: 	
                state = State.Shoot;
                break;
            case 2:
                if (dodgeEvocation)
                {
                    SpecificRAndomAction(dodgeEvocation, dodgeSpawn);
                    break;
                }
                state = State.Evocate;
                break;
            case 3:
                if (dodgeSpawn)
                {
                    SpecificRAndomAction(dodgeEvocation, dodgeSpawn);
                    break;
                }
                state = State.Spawn;
                break;
        }
    }

    private void SpecificRAndomAction(bool _evo, bool _spa)
    {
        if (_evo && _spa)
        {
            switch (Random.Range(0,2))
            {
                case 0:
                    state = State.TP;
                    break;
                case 1:
                    state = State.Shoot;
                    break;
            }
        }
        else
        {
            switch (Random.Range(0,3))
            {
                case 0:
                    state = State.TP;
                    break;
                case 1:
                    state = State.Shoot;
                    break;
                case 2:
                    if (_evo)
                        state = State.Evocate;
                    else if (_spa)
                        state = State.Spawn;
                    break;
            }
        }
    }

    public void Float(bool _float)
    {
        if (_float)
            gameObject.GetComponent<Levitation>().SetFloating();
        else
            gameObject.GetComponent<Levitation>().UnsetFloating();
    }
}
