using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header ("Properities")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Enemy_health_behaviour health;

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
        // Debug.Log(collision.tag);
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_health>().TakeDamage(damage);
            // Debug.Log("hit");
        }
        else if (collision.tag == "Projectile")
        {
            //FindObjectOfType<Enemy_health_behaviour>().TakeHit(1);
            health.TakeHit(1);
            //Debug.Log("Hit projectile");
        }
    }
}
