using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackState
{
    Fire,
    Fontain,
    None
}

public class MagicBoss_attack : MonoBehaviour
{
    [Header ("Projectiles")]
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private GameObject[] gravProjectiles;
    [SerializeField] private Transform fontainSpawn;

    [Header ("Attack")]
    [SerializeField] private float distanceSpawn;
    [SerializeField] private float timeSpawning;
    [Range (0,1)]
    [SerializeField] private float rozptyl;
    [SerializeField] private Transform target;
    [SerializeField] private float power;
    private float actualTime;

    [Header ("Kind of attack")]
    [SerializeField] private AttackState state;

    [Header ("Weakness")]
    [SerializeField] private GameObject mainBody;

    private SpriteRenderer pic;

    private int proj;

    private void Awake()
    {
        proj = 0;

        state = AttackState.None;

        pic = GetComponent<SpriteRenderer>();

        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        switch(state)
        {
            case AttackState.Fire:
                Spawn();
                break;
            case AttackState.Fontain:
                SetFontain();
                break;
            case AttackState.None:
                break;
        }
    }

    private void SetFontain()
    {
        if (actualTime >= timeSpawning * 2)
        {
            actualTime = 0;

            float startX = -3 * rozptyl;
            float startY = 3 * rozptyl;

            for (int i = 0; i < gravProjectiles.Length; i ++)
            {
                if (!gravProjectiles[i].activeInHierarchy)
                {
                    gravProjectiles[i].transform.position = fontainSpawn.position;
                    gravProjectiles[i].GetComponent<Enemy_projectile>().SetDirection(new Vector3(startX * power, startY * power, 0));
                   // gravProjectiles[i].GetComponent<ProjectileRigid>().RBenable(true);
                }
                    
                startX += rozptyl;
            }

            SoundManager.PlaySound("wizzard_fc");
            StopShoot();
        }
        actualTime += Time.deltaTime;
    }

    private void Spawn()
    {
        if (actualTime >= timeSpawning)
        {
            actualTime = 0;
            Preparing();
        }
        actualTime += Time.deltaTime;
    }

    private void Preparing()
    {
        if (proj >= projectiles.Length)
        {
            Fire();
            StopShoot();
            return;
        }
        
        if (!projectiles[proj].activeInHierarchy)
        {
            Vector3 area = new Vector3(Random.Range(-distanceSpawn, distanceSpawn), Random.Range(-distanceSpawn, distanceSpawn), 0);

            projectiles[proj].GetComponent<Enemy_projectile>().DistantRespawn(transform.position + area);
            projectiles[proj].GetComponent<Enemy_projectile>().SetDirection(new Vector3(0, 0, 0));

            SoundManager.PlaySound("wizzard_fc");
        }

        proj += 1;
        
    }

    private void Fire()
    {
        for (int i = 0; i < projectiles.Length; i ++)
        {
            if (projectiles[i].activeInHierarchy)
            {
                projectiles[i].GetComponent<Enemy_projectile>().DelayedShoot();
            }
        }
                
    }

    private int FindProjectile()
    {
        for(int i = 0; i < projectiles.Length; i++)
        {
            if(!projectiles[i].activeInHierarchy)
                return i;
        }
        return -1;
    }

    public void SetShoot()
    {
        gameObject.GetComponent<MagicBoss_movement>().FreezeMovement(true);
        mainBody.GetComponent<MagicBoss_health>().multiplier = 1.8f;
        pic.color = new Color(1f, 0.7f, 0.7f, 1);

        Decide();
        //spawn = true;
        //proj = 0;
    }

    private void StopShoot()
    {
        state = AttackState.None;

        pic.color = Color.white;
        mainBody.GetComponent<MagicBoss_health>().multiplier = 1;
        gameObject.GetComponent<MagicBoss_movement>().FreezeMovement(false);
        gameObject.GetComponent<MagicBoss_controller>().SetNext(true);
    }

    private void Decide()
    {
        if (Random.value > 0.5f)
        {
            state = AttackState.Fire;
            proj = 0;
        } else {
            state = AttackState.Fontain;
            actualTime = 0;
        }
        //state = AttackState.Fontain;
    }
}
