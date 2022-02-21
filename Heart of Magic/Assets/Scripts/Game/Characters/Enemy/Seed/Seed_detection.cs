using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_detection : MonoBehaviour
{
    private GameObject seed;

    private void Awake()
    {
        seed = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            seed.GetComponent<EvilSeed>().WakeUp();
        }
    }
}
