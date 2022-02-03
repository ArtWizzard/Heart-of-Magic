using UnityEngine;

public class Energy_fireball : MonoBehaviour
{
    [Header ("Properities")]
    [SerializeField] private float speed;
    [SerializeField] public int damage;
    private float direction;
    private bool hit;
    private float lifeTime;
    private bool hitLogic;

    private BoxCollider2D BoxCollider;
    private Animator anim;

    private void Awake()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5) Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitLogic =  (collision.tag != "Player") && 
                    (collision.tag != "Item") && 
                    (collision.tag != "Doors_interface") && 
                    (collision.tag != "Barrier") &&
                    (collision.tag != "Decoration") &&
                    (collision.tag != "Area");

        if(hitLogic)
        {
            hit = true;
            BoxCollider.enabled = false;
            anim.SetTrigger("explode");
        }
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        BoxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
