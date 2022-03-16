using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private DataStorage storage;
    [SerializeField] public float duration;
    private CapsuleCollider2D coll;
    private float actualTime = 0;
    public int damage;

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
        damage = storage.beamDamage;
        RunOut();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (duration < actualTime)
            {
                gameObject.SetActive(false);
                actualTime = 0;

            }
            actualTime += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<MagicSound_duration>().StartSound();
        coll.enabled = true;
    }

    private void RunOut()
    {
        coll.enabled = false;
    }
    
}
