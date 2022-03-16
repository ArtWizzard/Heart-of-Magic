using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBoss_movement : MonoBehaviour
{
    [Header ("Teleportation")]
    [SerializeField] private Transform tp1;
    [SerializeField] private Transform tp2;
    [SerializeField] private Transform tp3;
    public Transform future;
    private int destination;

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        transform.position = RandomChoose().position;
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    public void RandomTP()
    {
        switch(destination)
        {
            case 1:
                if (Random.value > 0.5f)
                {
                    future = tp2;
                    destination = 2;
                }
                else
                {
                    future = tp3;
                    destination = 3;
                }
                break;
            case 2:
                if (Random.value > 0.5f)
                {
                    future = tp1;
                    destination = 1;
                }
                else
                {
                    future = tp3;
                    destination = 3;
                }
                break;
            case 3:
                if (Random.value > 0.5f)
                {
                    future = tp2;
                    destination = 2;
                }
                else
                {
                    future = tp1;
                    destination = 1;
                }
                break;
        }
        //future = tp3; // presna pozice
        SetPlace();
    }

    public void SetPlace()
    {
        transform.position = future.position;
        SoundManager.PlaySound("tp");
    }

    private Transform RandomChoose()
    {
        int rnd = Random.Range(0,3)/3;
        switch(rnd)
        {
            case 0:
                destination = 1;
                future = tp1;
                return tp1;
            case 1:
                destination = 2;
                future = tp2;
                return tp2;
            case 2:
                destination = 3;
                future = tp3;
                return tp3;
        }
        destination = 1;
        future = tp1;
        return tp1;
    }

    public void SetCollider()
    {
        boxCollider.enabled = true;
    }
    public void UnsetCollider()
    {
        boxCollider.enabled = false;
    }
}
