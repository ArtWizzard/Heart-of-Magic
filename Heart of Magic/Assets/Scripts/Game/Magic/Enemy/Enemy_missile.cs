using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_missile : MonoBehaviour
{
    [Header ("Power")]
    [SerializeField] private int damage;
    [SerializeField] float speed;

    [Header ("Movement")]
    //[SerializeField] public Transform spawnPoint;
    [SerializeField] private Transform target;
    [SerializeField] private float lifeTime;
    private float actualTime;
    private bool flying;

    private CircleCollider2D cc;
    private Animator anim;

    private void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();

        flying = true;
        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        CheckLifetime();
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool destroy =  (collision.tag == "Barrier") ||
                        (collision.tag == "Energy_ball") ||
                        (collision.tag == "Artilery_ball") ||
                        (collision.tag == "Beam") ||
                        (collision.tag == "Ground");

        bool hit =      (collision.tag == "Player");

        if (destroy)
            Stop();

        if (hit)
        {
            Stop();
            collision.GetComponent<Player_health>().TakeDamage(damage);
        }
    }

    public void Shoot(Transform _fireSpawn)
    {
        gameObject.SetActive(true);
        transform.position = _fireSpawn.position;
        cc.enabled = true;
        flying = true;
    }

    private void Stop()
    {
        cc.enabled = false;
        flying = false;
        anim.SetTrigger("explode");
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Move()
    {
        if (flying)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void CheckLifetime()
    {
        if (actualTime > lifeTime)
        {
            anim.SetTrigger("explode");
            actualTime = 0;
        }
        actualTime += Time.deltaTime;
    }
}
