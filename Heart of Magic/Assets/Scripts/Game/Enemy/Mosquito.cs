using UnityEngine;

public class Mosquito : MonoBehaviour
{
    [Header ("Power")]
    [SerializeField] private int damage; 

    [Header ("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float distance;   
    private bool moving_right;
    private float leftEdge;
    private float rightEdge;


    void Awake()
    {
        leftEdge = transform.position.x - distance;
        rightEdge = transform.position.x + distance;
    }

    void Update()
    {
        if(moving_right)
        {
            if(transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else moving_right = false;
        }
        else
        {
            if(transform.position.x > leftEdge)
            {
                 transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else moving_right = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_health>().TakeDamage(damage);
            Debug.Log("hit");
        }
    }
}
