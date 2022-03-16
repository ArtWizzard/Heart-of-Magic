using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack : MonoBehaviour
{
    [Header ("Projectiles")]
    [SerializeField] private GameObject[] projectiles;

    [Header ("Attack")]
    [SerializeField] private float distanceSpawn;
    [SerializeField] private float timeSpawning;
    [Range (0,1)]
    [SerializeField] private float rozptyl;
    [SerializeField] private Transform target;
    private float actualTime;

    [Header ("Weakness")]
    [SerializeField] private GameObject mainBody;

    private SpriteRenderer pic;

    private bool spawn;
    private int proj;

    private void Awake()
    {
        spawn = false;
        proj = 0;

        pic = GetComponent<SpriteRenderer>();

        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (spawn)
        {
            if (actualTime >= timeSpawning)
            {
                actualTime = 0;
                Preparing();
            }
            actualTime += Time.deltaTime;
        }
    }

    private void Preparing()
    {
        if (proj >= projectiles.Length)
        {
            spawn = false;
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
        gameObject.GetComponent<Boss_movement>().FreezeMovement(true);
        mainBody.GetComponent<Boss_health>().multiplier = 1.8f;
        pic.color = new Color(1f, 0.7f, 0.7f, 1);

        spawn = true;
        proj = 0;
    }

    private void StopShoot()
    {
        pic.color = Color.white;
        mainBody.GetComponent<Boss_health>().multiplier = 1;
        gameObject.GetComponent<Boss_movement>().FreezeMovement(false);
        gameObject.GetComponent<Boss_controller>().SetNext(true);
    }
}
