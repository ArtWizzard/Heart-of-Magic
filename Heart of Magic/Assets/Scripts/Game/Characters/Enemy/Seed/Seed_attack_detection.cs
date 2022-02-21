using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_attack_detection : MonoBehaviour
{
    private GameObject seed;
    private int damage;

    private void Awake()
    {
        seed = gameObject.transform.parent.gameObject;
        damage = seed.GetComponent<EvilSeed>().damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_health>().TakeDamage(damage);
            seed.GetComponent<EvilSeed>().Explode();
        }
    }
}
