using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MBossState
{
    Spawn,
    Attack
}

public class MagicBoss_controller : MonoBehaviour
{
    [Header ("Time")]
    [SerializeField] private float timeDelay;
    [SerializeField] private float hystereze;
    private float actualDelay;

    [Header ("State")]
    private MBossState state;
    private bool free;

    [Header ("Body")]
    [SerializeField] private GameObject hittableBody;
    [SerializeField] public int damage;

    [Header ("Data storage")]
    [SerializeField] private DataStorage storage;

    private void Awake()
    {
        //state = MBossState.Spawn;
        state = MBossState.Attack;

        free = true;
        actualDelay  = 0;

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
            switch(state)
            {
                case MBossState.Attack:
                    gameObject.GetComponent<MagicBoss_attack>().SetShoot();
                    free = false;
                    RandomAction();
                    break;

                case MBossState.Spawn:
                    gameObject.GetComponent<MagicBoss_spawn>().SetSpawn();
                    hittableBody.GetComponent<MagicBoss_health>().multiplier = 1.5f;
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
        bool dodgeSpawn = gameObject.GetComponent<MagicBoss_spawn>().GhostsToSpawn();

        switch (Random.Range(0,3))
        {
            case 0: 	
                state = MBossState.Attack;
                break;
            case 1: 	
                state = MBossState.Attack;
                break;
            case 2:
                if (!dodgeSpawn)
                {
                    SpecificRAndomAction();
                    break;
                }
                state = MBossState.Spawn;
                break;
        }

        //state = MBossState.Spawn;
        //state = MBossState.Attack;
    }

    private void SpecificRAndomAction()
    {
        switch (Random.Range(0,1))
        {
            case 0: 	
                state = MBossState.Attack;
                break;
        }
    }

    public void SetNext(bool _state)
    {
        free = _state;
        hittableBody.GetComponent<MagicBoss_health>().multiplier = 1;
    }
}
