using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceKeeper : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    [Header ("Speed Multiplier")]
    [SerializeField] private float onExit;
    [SerializeField] private float onEnter;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            boss.GetComponent<MagicBoss_movement>().multiplier = onEnter;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            boss.GetComponent<MagicBoss_movement>().multiplier = onExit;
        }
    }
}
