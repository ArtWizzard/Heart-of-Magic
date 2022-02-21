using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSeed : MonoBehaviour
{
    [Header ("Attack")]
    [SerializeField] public int damage;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float movSpeed;
    [SerializeField] private Transform target;
    private int direction;
    private bool near = false;

    private Rigidbody2D rB;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (near)
        {
            if (target.position.x > transform.position.x)
                direction = 1;
            else
                direction = -1;

            transform.position = new Vector3(transform.position.x + direction * movSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    public void WakeUp()
    {
        rB.gravityScale = fallSpeed;
        near = true;
    }

    public void Explode()
    {
        gameObject.SetActive(false);
    }
}
