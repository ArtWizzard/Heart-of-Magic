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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Collider2D>().tag == "Enemy")
        {
            if (collision.tag == "Energy_ball")
            {
                TakeHit(collision.GetComponent<Energy_fireball>().damage);
            }
            else if (collision.tag == "Artilery_ball")
            {
                TakeHit(collision.GetComponent<Bomb_artilery>().damage);
            }
            else if (collision.tag == "Barrier")
            {
                TakeHit(collision.GetComponent<Barrier>().damage);
            }
            else if (collision.tag == "Beam")
            {
                TakeHit(collision.GetComponent<Beam>().damage);
            }
        }

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
