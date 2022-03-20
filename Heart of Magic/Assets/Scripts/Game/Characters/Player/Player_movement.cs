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
    private float HorizontalInput;

    private bool minule;

    private void Awake()
    {
        //Grap references to rigidbody, boxcollider, animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        minule = isGrounded();
    }

    private void Update()
    {
        SelfMovement();
    }

    private void SelfMovement()
    {
        // Pohyb do stran
        //if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        HorizontalInput = Input.GetAxis("Horizontal");
        /*
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            HorizontalInput = 0;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            HorizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            HorizontalInput = -1;
        }
        else
        {
            HorizontalInput = 0;
        }*/


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

        if (minule == false && isGrounded())
        {
            if (Random.value > 0.93f)
            {
                string sound = "wizzard_break";
                switch(Random.Range(0,4))
                {
                    case 0:
                        sound = "wizzard_break";
                        break;
                    case 1:
                        sound = "wizzard_zada2";
                        break;
                    case 2:
                        sound = "wizzard_zada1";
                        break;
                    case 3:
                        sound = "wizzard_kolena";
                        break;
                }
                SoundManager.PlaySound(sound);
            }
                    
        }
        minule = isGrounded();

        // Set animator parameters
        anim.SetBool("Run", HorizontalInput != 0);      // Začne 
        anim.SetBool("Jump", !isGrounded());            // Dopadne
        anim.SetFloat("yVelocity", body.velocity.y);    // Fáze skoku/pádu
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit =   Physics2D.BoxCast(circleCollider.bounds.center, circleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool isMoving()
    {
        return HorizontalInput != 0;
    }
}
