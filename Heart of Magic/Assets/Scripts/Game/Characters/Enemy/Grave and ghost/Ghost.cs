using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header ("Properities")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Enemy_health health;

    [Header ("Power")]
    [SerializeField] private int damage; 
    
    [Header ("Movement")]
    [SerializeField] private float speed;
    [SerializeField] Transform target;
    [SerializeField] private float stopDistance;
    [SerializeField] private float backDistance;

    private bool stopLogic;
    private bool backLogic;
    private float xPosS;
    private float yPosS;
    private float xPosT;
    private float yPosT;

    void Awake()
    {
        transform.position = spawnPoint.position;
        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        xPosS = transform.position.x;
        yPosS = transform.position.y;
        xPosT = target.position.x;
        yPosT = target.position.y;

        stopLogic = Mathf.Abs(xPosS - xPosT) < stopDistance && Mathf.Abs(yPosS - yPosT) < stopDistance;
        backLogic = Mathf.Abs(xPosS - xPosT) < backDistance && Mathf.Abs(yPosS - yPosT) < backDistance;

        if (backLogic)
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        else if (stopLogic)
            transform.position = transform.position;
        else
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject other = collision.gameObject;

        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_health>().TakeDamage(damage);
        }
        /*
        else if (collision.tag == "Energy_ball")
        {
            health.TakeHit(collision.GetComponent<Energy_fireball>().damage);
        }
        else if (collision.tag == "Artilery_ball")
        {
            health.TakeHit(collision.GetComponent<Bomb_artilery>().damage);
        }
        else if (collision.tag == "Barrier")
        {
            health.TakeHit(collision.GetComponent<Barrier>().damage);
        } 
        else if (collision.tag == "Beam")
        {
            health.TakeHit(collision.GetComponent<Beam>().damage);
        }
*/
    }
    public void DistantRespawn(Vector3 _spawn)
    {
        gameObject.SetActive(true);
        transform.position = _spawn;
    }

    public void ReSpawn()
    {
        transform.position = spawnPoint.position;
        health.ReLoad();
        gameObject.SetActive(true);
    }
}
