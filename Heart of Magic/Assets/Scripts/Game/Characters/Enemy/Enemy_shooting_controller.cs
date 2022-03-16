using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting_controller : MonoBehaviour
{
    [Header ("Attack")]
    [SerializeField] private float fireDelay;
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform target;
    [SerializeField] private Transform firePoint;

    private float actualTime = 0;

    private void Awake()
    {
        actualTime = 0;

        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (actualTime > fireDelay)
        {
            Fire();
            //Debug.Log("fire");
            actualTime = 0;
        }
        actualTime += Time.deltaTime;
    }

    private void Fire()
    {
        if (FindProjectile() != -1)
        {
            SoundManager.PlaySound("magic_shoot");
            float xDir = target.position.x - transform.position.x;
            float yDir = target.position.y - transform.position.y;

            //GameObject projectile = projectiles[FindProjectile()];

            projectiles[FindProjectile()].transform.position = firePoint.position;
            projectiles[FindProjectile()].GetComponent<Enemy_projectile>().SetDirection(new Vector3(xDir, yDir, 0).normalized);
            
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
}
