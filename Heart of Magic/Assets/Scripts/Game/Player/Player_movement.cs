//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump_power;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    private Animator anim;
    

    private void Awake()
    {
        //Grap references to rigidbody, boxcollider, animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Pohyb do stran
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);

        // Otáčení
        if(HorizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (HorizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Skok
        if(Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jump_power);
            anim.SetBool("Jump", true);
        }

        // Set animator parameters
        anim.SetBool("Run", HorizontalInput != 0);      // Začne 
        anim.SetBool("Jump", !isGrounded());            // Dopadne
        anim.SetFloat("yVelocity", body.velocity.y);    // Fáze skoku/pádu

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(circleCollider.bounds.center, circleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
