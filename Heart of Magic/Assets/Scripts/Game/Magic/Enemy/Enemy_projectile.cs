using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum magicType{
    Fire,
    Poison
};

public class Enemy_projectile : MonoBehaviour
{
    [Header ("Select")]
    public magicType type;

    [Header ("Power")]
    [SerializeField] private int damage;
    [SerializeField] float speed;

    [Header ("Movement")]
    [SerializeField] private float lifeTime;
    private float actualTime;
    private Vector3 direction;

    private CircleCollider2D cc;
    private Animator anim;
    //private bool hitLogic;

    private void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
        if (actualTime > lifeTime)
        {
            gameObject.SetActive(false);
        }
        actualTime += Time.deltaTime;
    }

    public void SetDirection(Vector3 _direction)
    {
        //Debug.Log("SetDirection");
        direction = _direction;     // nastaví aktuální směr
        gameObject.SetActive(true); // rožne objekt
        cc.enabled = true;          // zapne collider
        actualTime = 0;             // spustí čas života
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

    private void Stop()
    {
        cc.enabled = false;
        direction = new Vector3(0, 0, 0);
        anim.SetTrigger("explode");
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
