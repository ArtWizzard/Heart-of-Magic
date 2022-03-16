using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneInforming : MonoBehaviour
{
    [Header ("Boss")]
    [SerializeField] private GameObject boss;

    [Header ("Zones")]
    [SerializeField] private int exitZone;
    [SerializeField] private int enterZone;


    private CircleCollider2D cc;

    private void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
            boss.GetComponent<Boss_movement>().zone = enterZone;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
            boss.GetComponent<Boss_movement>().zone = exitZone;
    }
}
