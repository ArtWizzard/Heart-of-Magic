using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action{
    Shoot,
    Spawn,
    Dash,
    Rain
};

public class Boss_controller : MonoBehaviour
{
    [Header ("Time")]
    [SerializeField] private float timeDelay;
    [SerializeField] private float hystereze;
    private float actualDelay;

    [Header ("State")]
    private Action action;
    private bool free;

    [Header ("Body")]
    [SerializeField] private GameObject hittableBody;
    [SerializeField] public int damage;

    [Header ("Data storage")]
    [SerializeField] private DataStorage storage;

    private Animator anim;

    private void Awake()
    {
        action = Action.Shoot; // that will be first state
        //action = Action.Spawn;
        //action = Action.Dash;
        //action = Action.Rain;

        free = true;
        actualDelay  = 0;

        anim = GetComponent<Animator>();

        damage = (int)(damage * storage.diffMulti);
    }

    private void Update()
    {
        ActionDecider();
    }

    private void ActionDecider()
    {
        if (actualDelay >= timeDelay + Random.Range(-hystereze, hystereze) && free)
        {
            switch(action)
            {
                case Action.Shoot:
                    gameObject.GetComponent<Boss_attack>().SetShoot();
                    free = false;
                    RandomAction();
                    break;

                case Action.Spawn:
                    gameObject.GetComponent<Boss_spawn>().SetSpawn();
                    free = false;
                    RandomAction();
                    break;

                case Action.Dash:
                    gameObject.GetComponent<Boss_movement>().SetDash();
                    free = false;
                    RandomAction();
                    break;

                case Action.Rain:
                    gameObject.GetComponent<Boss_rain>().SetRain();
                    free = false;
                    RandomAction();
                    break;
            }
            actualDelay = 0;
        }
        actualDelay += Time.deltaTime;
    }

    private void RandomAction()
    {
       bool dodgeSpawn = gameObject.GetComponent<Boss_spawn>().GhostsToSpawn();
        


        switch (Random.Range(0,4))
        {
            case 0: 	
                action = Action.Shoot;
                break;
            case 1:
                if (!dodgeSpawn)
                {
                    SpecificRAndomAction();
                    break;
                }
                action = Action.Spawn;
                break;
            case 2:
                action = Action.Dash;
                break;
            case 3:
                action = Action.Rain;
                break;
        }

        //action = Action.Shoot;
    }

    private void SpecificRAndomAction()
    {
        switch (Random.Range(0,3))
        {
            case 0: 	
                action = Action.Shoot;
                break;
            case 1:
                action = Action.Dash;
                break;
            case 2:
                action = Action.Rain;
                break;
        }
    }

    public void SetNext(bool _state)
    {
        free = _state;
    }

    public void BossLastWords()
    {
        hittableBody.GetComponent<Boss_health>().BossKilled();
    }
}
