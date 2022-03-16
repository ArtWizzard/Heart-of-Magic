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
    public bool range = false;

    private float x;
    private float y;
    private float z;

    private Rigidbody2D rB;
    private Animator anim;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (near)
        {
            if (target.position.x > transform.position.x)
            {
                direction = 1;
                transform.localScale = new Vector3(x, y, z);
            }
            else
            {
                direction = -1;
                transform.localScale = new Vector3(-x, y, z);

            }

            transform.position = new Vector3(transform.position.x + direction * movSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    public void WakeUp()
    {
        rB.gravityScale = fallSpeed;
        near = true;
        anim.SetTrigger("Run");
    }

    public void SetExplode()
    {
        anim.SetTrigger("Explode");
        SoundManager.PlaySound("explo1");
        movSpeed = movSpeed / 2;
    }

    public void GiveDamage()
    {
        if (range)
            target.GetComponent<Player_health>().TakeDamage(damage);
    }

    public void Explode()
    {

        gameObject.SetActive(false);
    }
}
