using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_attack_detection : MonoBehaviour
{
    private GameObject seed;
    private int damage;
    //public bool near = false;

    private void Awake()
    {
        seed = gameObject.transform.parent.gameObject;
        damage = seed.GetComponent<EvilSeed>().damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            seed.GetComponent<EvilSeed>().range = true;
            seed.GetComponent<EvilSeed>().SetExplode();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            seed.GetComponent<EvilSeed>().range = false;
    }
}
