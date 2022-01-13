using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health_behaviour : MonoBehaviour
{
    [SerializeField] private float Hitpoints;
    [SerializeField] private float MaxHitpoints = 5;
    [SerializeField] private Enemy_healthBar_behaviour HealthBar;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
        Debug.Log("Damage taken");

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
