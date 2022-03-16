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

    private Transform target;

    private CircleCollider2D cc;
    private Animator anim;
    //private bool hitLogic;

    private void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();
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
        //SoundManager.PlaySound("magic_shoot");
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
        /*
        string sound = "explode1";
        switch(Random.Range(0,3))
        {
            case 0:
                sound = "explode1";
                break;
            case 1:
                sound = "explode2";
                break;
            case 2:
                sound = "explode3";
                break;
        }
        SoundManager.PlaySound(sound);*/
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void DistantRespawn(Vector3 _spawn)
    {
        transform.position = _spawn;
    }

    public void DelayedShoot()
    {
        /*
        float rozptylX = Random.Range(-_rozptyl, _rozptyl);
        float rozptylY = Random.Range(-_rozptyl, _rozptyl);

        Debug.Log(rozptylX);
        Debug.Log(rozptylY);
*/
        Vector3 direct = target.position - transform.position;
        /*direct = direct.normalized;
        direct = new Vector3(   direct.x + rozptylX, 
                                direct.y + rozptylY, 
                                0).normalized;
*/
        SetDirection(direct.normalized);
    }
}
