using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bodyMov
{
    Normal,
    Dash,
    None
}

public class Boss_movement : MonoBehaviour
{
    /*[Header ("State")]
    [SerializeField] */private bodyMov state;

    [Header ("Player")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform staticTarget;

    [Header ("Speed")]
    [SerializeField] private float farSpeed;
    [SerializeField] private float middleSpeed;
    [SerializeField] private float nearSpeed;
    [HideInInspector] public int zone;
    private float speed;
    

    [Header ("Body Attack")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float timeWait;
    [SerializeField] private float timeSetervation;

    private float timeToDash;
    private bool dash;

    

    private void Awake()
    {
        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();

        speed = farSpeed;
        zone = 3;
        state = bodyMov.Normal;
        timeToDash = 0;
    }

    private void Update()
    {
        switch(state)
        {
            case bodyMov.Normal:
                Move();
                break;
            case bodyMov.Dash:
                Dash();
                break;
            case bodyMov.None:
                break;
        }
    }

    public void SetDash()
    {
        staticTarget.position = target.position;
        timeToDash = 0;
        state = bodyMov.Dash;
        //Debug.Log("dash");
    }

    public void FreezeMovement(bool _freeze)
    {
        //Debug.Log("Freeze");
        //Debug.Log(_freeze);
        if (_freeze)
        {
            state = bodyMov.None;
        } else {
            state = bodyMov.Normal;
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        switch(zone)
        {
            case 1:
                speed = nearSpeed;
                break;
            case 2:
                speed = middleSpeed;
                break;
            case 3:
                speed = farSpeed;
                break;
        }
    }

    private void Dash()
    {
        if (timeToDash >= timeWait)
        {
            transform.position = Vector2.MoveTowards(transform.position, staticTarget.position, dashSpeed * Time.deltaTime);
            if (transform.position == staticTarget.position || timeToDash - timeWait > timeSetervation)
            {
                state = bodyMov.Normal;
                ReturnStop();
            }
        }
        timeToDash += Time.deltaTime;
    }

    private void ReturnStop()
    {
        gameObject.GetComponent<Boss_controller>().SetNext(true);
    }
}
