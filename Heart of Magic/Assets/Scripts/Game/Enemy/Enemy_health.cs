using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    [SerializeField] private float Hitpoints;
    [SerializeField] private float MaxHitpoints = 5;
    [SerializeField] private Enemy_healthBar HealthBar;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
        //Debug.Log("Damage taken");

        if (Hitpoints <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void ReLoad()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
    }
}
