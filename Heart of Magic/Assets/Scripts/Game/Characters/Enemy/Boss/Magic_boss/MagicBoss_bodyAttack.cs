using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoss_bodyAttack : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    [SerializeField] private DataStorage storage;

    private int damage;

    private void Awake()
    {
        damage = (int)(damage * storage.diffMulti);
        damage = boss.GetComponent<MagicBoss_controller>().damage;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player_health>().TakeDamage(damage);
        }
    }
}
