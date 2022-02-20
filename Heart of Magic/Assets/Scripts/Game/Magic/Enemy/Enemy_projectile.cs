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
    private Vector3 direction;

    private CircleCollider2D cC;
    private Rigidbody2D rB;
    private float lifeTime;
    private bool hitLogic;
    private bool hit = true;

    private float xDir;
    private float yDir;
    

    private void Awake()
    {
        cC = GetComponent<CircleCollider2D>();
        rB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hit) return;
       // float movSpeed = speed * Time.deltaTime;
        //transform.Translate(movSpeed * new Vector3(xDir, yDir, 0), Space.World);
        rB.velocity = transform.TransformDirection(new Vector3(xDir * speed, yDir * speed, speed * Time.deltaTime));

        lifeTime += Time.deltaTime;
        if (lifeTime > 5)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitLogic =  (collision.tag != "Item") && 
                    (collision.tag != "Artilery_ball") && // !!!! tohle
                    (collision.tag != "Doors_interface") && 
                    (collision.tag != "Barrier") &&
                    (collision.tag != "Decoration") &&
                    (collision.tag != "Area") &&
                    (collision.tag != "Dialogue") &&
                    (collision.tag != "Enemy");

        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_health>().TakeDamage(damage);
        } else if (hitLogic) 
        {
            cC.enabled = false;
            gameObject.SetActive(false);
        }
    }

    public void SetDirection(Transform _firePoint, Transform _aim)
    {
        lifeTime = 0;
        gameObject.SetActive(true);
        hit = false;
        cC.enabled = true;

        //  nastavení pozice
        transform.position = _firePoint.position;

        //  výpočet směru
        int delta = 1;//_aim.position.x - _firePoint.position.x;

        if (_aim.position.x > _firePoint.position.x )
            delta = 1;
        else
            delta = -1;

        xDir = delta;
        yDir = ( (_aim.position.y - _firePoint.position.y) / (_aim.position.x - _firePoint.position.x)) * delta;

    }
}
