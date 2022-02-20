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

    void Awake()
    {
        transform.position = spawnPoint.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject other = collision.gameObject;

        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_health>().TakeDamage(damage);
        }
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

    }

    public void ReSpawn()
    {
        transform.position = spawnPoint.position;
        health.ReLoad();
        gameObject.SetActive(true);
    }
}
