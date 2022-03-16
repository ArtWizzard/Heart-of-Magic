using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBoss_attack : MonoBehaviour
{
    [Header ("Projectiles")]
    [SerializeField] private GameObject[] projectiles;

    [Header ("Missiles")]
    [SerializeField] private GameObject[] missiles;

    [Header ("Attack")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;
    [Range (0,1)]
    [SerializeField] private float rozptyl;
    [SerializeField] private float missileDelay;
    private int loadedMissiles;
    private float actualDelay = Mathf.Infinity;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        loadedMissiles = 0;

        if (target == null)
            target = target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        MissileFiring();
    }

    private void MissileFiring() // counting missiles
    {
        if (loadedMissiles > 0 && actualDelay >= missileDelay)
        {
            Aim();

            actualDelay = 0;
            loadedMissiles -= 1;
            if (loadedMissiles <= 0)
                anim.SetBool("Shooting", false);
        }
        actualDelay += Time.deltaTime;
    }

    public void SetAttack() // started by animation
    {
        
        if (Random.Range(0,2) != 0)
        {
            Fire();
            SoundManager.PlaySound("magic_shoot");
            //Debug.Log("fire");
        } else {
            loadedMissiles = missiles.Length;
            //Debug.Log("missile");
        }
        //Fire();
    }

    private void Fire() // fire towards player one projectile
    {
        for(int i = 0; i < projectiles.Length; i++)
        {
            if(!projectiles[i].activeInHierarchy)
            {
                float xDir = target.position.x - transform.position.x;
                float yDir = target.position.y - transform.position.y;
                Vector3 predir = new Vector3(xDir, yDir, 0).normalized;
                Vector3 dir = new Vector3(  predir.x - rozptyl * 2 + i * rozptyl, 
                                            predir.y - rozptyl * 2 + i * rozptyl, 
                                            0).normalized; // Random.Range(-rozptyl, rozptyl)

                projectiles[i].transform.position = firePoint.position;
                projectiles[i].GetComponent<Enemy_projectile>().SetDirection(dir);
            }
        }

        anim.SetBool("Shooting", false);
    }

    private void Aim()  // start counting missiles
    {
        if (FindMissile() != -1)
        {
            missiles[FindMissile()].GetComponent<Enemy_missile>().Shoot(firePoint);
            SoundManager.PlaySound("magic_shoot");
        }
    }

// finding

    private int FindMissile()
    {
        for(int i = 0; i < missiles.Length; i++)
        {
            if(!missiles[i].activeInHierarchy)
                return i;
        }
        return -1;
    }
}
