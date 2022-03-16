using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovStatus
{
    Distance,
    Follow,
    None
}

public class MagicBoss_movement : MonoBehaviour
{
    
    [Header ("Movement")]
    [SerializeField] private float speed;
    [SerializeField] Transform target;
    [SerializeField] private float stopDistance;
    [SerializeField] private float backDistance;

    public float multiplier;

    [Header ("Phases")]
    [SerializeField] private float minTimeChange;
    [SerializeField] private float maxTimeChange;
    private MovStatus status;
    private MovStatus tempStatus;
    private float timeChange;
    private float actualTime;
/*
    private bool stopLogic;
    private bool backLogic;
    private float xPosS;
    private float yPosS;
    private float xPosT;
    private float yPosT;
*/

    private void Awake()
    {
        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();

        status = MovStatus.Follow;
        tempStatus = status;
        timeChange = Random.Range(minTimeChange, maxTimeChange);
        actualTime = 0;
        multiplier = 1;
    }

    private void Update()
    {
        switch(status)
        {
            case MovStatus.Distance:
                KeepDistance();
                break;
            case MovStatus.Follow:
                Follow();
                break;
        }

        if (actualTime >= timeChange)
        {
            actualTime = 0;

            if (Random.value > 0.5f)
            {
                status = MovStatus.Distance;
                speed = 2f;
            }
            else
            {
                status = MovStatus.Follow;
                speed = 1.5f;
            }
        }
        actualTime += Time.deltaTime;
    }

    private void KeepDistance()
    {
        float xPosS = transform.position.x;
        float yPosS = transform.position.y;
        float xPosT = target.position.x;
        float yPosT = target.position.y;

        bool stopLogic = Mathf.Abs(xPosS - xPosT) < stopDistance && Mathf.Abs(yPosS - yPosT) < stopDistance;
        bool backLogic = Mathf.Abs(xPosS - xPosT) < backDistance && Mathf.Abs(yPosS - yPosT) < backDistance;

        if (backLogic)
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * multiplier * Time.deltaTime);
        else if (stopLogic)
            transform.position = transform.position;
        else
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * multiplier * Time.deltaTime);
    }

    private void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * multiplier * Time.deltaTime);
    }

    public void FreezeMovement(bool _freeze)
    {
        if (_freeze)
        {
            tempStatus = status;
            status = MovStatus.None;
        } else {
            status = tempStatus;
        }
    }
}
