//  using System.Collections;
//  using System.Collections.Generic;
using UnityEngine;

public class Bomb_artilery : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float up;
    //[SerializeField] private float power;
    private float direction; // right or left
    private bool hit;
    private float lifeTime;

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
        float movementSpeed = power * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5) Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
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
        body.velocity = new Vector2(0,up);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
