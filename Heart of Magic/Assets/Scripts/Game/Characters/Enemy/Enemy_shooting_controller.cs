using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting_controller : MonoBehaviour
{
    [Header ("Holders")]
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform aim;

    [Header ("Attack")]
    [SerializeField] private float shootingPeriod;
    [SerializeField] private Transform firePoint;

    private float actualTime = Mathf.Infinity;

    private void Update()
    {
        if (actualTime >= shootingPeriod && FindProjectiles() != -1)
        {
            //projectiles[0].GetComponent<Enemy_projectile>().SetDirection(firePoint, aim);
            Attack();
            actualTime = 0;
        }
        actualTime += Time.deltaTime;
    }

    private void Attack()
    {
        if (FindProjectiles() == -1)
            return;
        projectiles[FindProjectiles()].GetComponent<Enemy_projectile>().SetDirection(firePoint, aim);
    }

    //  Najde nejlepší energyball
    private int FindProjectiles()
    {
        for(int i = 0; i < projectiles.Length; i++)
        {
            if(!projectiles[i].activeInHierarchy)
                return i;
        }
        return -1;  //  vrať hodnotu zápornou, jestliže nemá žádný volný energyball
    }
}
