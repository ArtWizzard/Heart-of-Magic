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
    private Animator anim;
    

    private void Awake()
    {
        //Grap references to rigidbody, boxcollider, animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        if(Input.GetKey(KeyCode.Space) && isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jump_power);
        }

        // Set animator parameters
        anim.SetBool("Run", HorizontalInput != 0);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
