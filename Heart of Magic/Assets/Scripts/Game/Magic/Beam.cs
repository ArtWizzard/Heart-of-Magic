using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private DataStorage storage;
    [SerializeField] private float duration;
    private CapsuleCollider2D collider;
    private float actualTime = 0;
    public int damage;

    private void Awake()
    {
        collider = GetComponent<CapsuleCollider2D>();
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
        collider.enabled = true;
    }

    private void RunOut()
    {
        collider.enabled = false;
    }
}
