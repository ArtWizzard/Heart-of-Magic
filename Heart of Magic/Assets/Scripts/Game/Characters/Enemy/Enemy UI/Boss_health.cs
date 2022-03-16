using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_health : MonoBehaviour
{
    [SerializeField] private float Hitpoints;
    [SerializeField] private float MaxHitpoints = 5;
    [SerializeField] private Enemy_healthBar HealthBar;

    [Header ("Action")]
    [SerializeField] private bool startWithDeath;
    [SerializeField] private GameObject[] objectsToActive;
    [SerializeField] private GameObject[] objectsToDeactive;
    //[SerializeField] private bool instantDrop = false;

    //[SerializeField] private string deathAction;

    [Header ("Animation")]
    [SerializeField] private Animator anim;

    [Header ("Loot")]
    [SerializeField] private GameObject[] loots;

    public float multiplier;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
        multiplier = 1;
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
        Hitpoints -= damage * multiplier;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);

        if (Hitpoints <= 0)
        {
            anim.SetTrigger("death");
        }
    }

    public void ReLoad()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
    }

    private void Death()
    {
        for (int i = 0; i < objectsToActive.Length; i++)
        {
            objectsToActive[i].SetActive(true);
        }
        for (int i = 0; i < objectsToDeactive.Length; i++)
        {
            objectsToDeactive[i].SetActive(false);
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void BossKilled()
    {
        for (int i = 0; i < loots.Length; i++)
        {
            loots[i].transform.position = transform.position;
            loots[i].SetActive(true);
        }
        Death();
    }
}
