//  using System.Collections;
//  using System.Collections.Generic;
using UnityEngine;

public class Bomb_artilery : MonoBehaviour
{
    [Header ("Properities")]
    [SerializeField] private float power;
    [SerializeField] private float up;
    [SerializeField] public int damage;

    private float direction; // right or left
    private bool hit;
    private float lifeTime;
    private float rndUp;
    private float rndPower;
    private float rndSpeed;
    private bool hitLogic;

    private CircleCollider2D cCollider;
    private Animator anim;
    private Rigidbody2D body;

    private void Awake()
    {
        cCollider = GetComponent<CircleCollider2D>();
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (hit) return;
        float movementSpeed = power * Time.deltaTime * direction * ((10+rndSpeed)/10);
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5) Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitLogic =  (collision.tag != "Player") && 
                    (collision.tag != "Item") && 
                    (collision.tag != "Artilery_ball") && // !!!! tohle
                    (collision.tag != "Doors_interface") && 
                    (collision.tag != "Barrier") &&
                    (collision.tag != "Decoration") &&
                    (collision.tag != "Area") &&
                    (collision.tag != "Dialogue");

        if(hitLogic)
        {
            hit = true;
            cCollider.enabled = false;
            gameObject.SetActive(false);
            //  anim.SetTrigger("explode");
        }
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        cCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        rndUp = Random.Range(-2f,2f);
        rndPower = Random.Range(-2f,2f);
        rndSpeed = Random.Range(-2f,2f);
        
        body.velocity = new Vector2(direction*(power + rndPower),up + rndUp);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
