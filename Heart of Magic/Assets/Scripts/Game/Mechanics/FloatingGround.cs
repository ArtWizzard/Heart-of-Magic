using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingGround : MonoBehaviour
{
    [Header ("Route")]
    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform secondPosition;
    [Range(0,10)]
    [SerializeField] private float speed;

    private bool forward = true;

    private void Awake()
    {
        transform.position = firstPosition.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (forward)
        {
            transform.position = Vector2.MoveTowards(transform.position, secondPosition.position, speed * Time.deltaTime);
            if (transform.position == secondPosition.position)
                forward = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, firstPosition.position, speed * Time.deltaTime);
            if (transform.position == firstPosition.position)
                forward = true;
        }
            
    }
}
