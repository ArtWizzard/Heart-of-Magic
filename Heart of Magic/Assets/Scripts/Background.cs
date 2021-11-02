using UnityEngine;

public class Background : MonoBehaviour
{
    

    [SerializeField] private float parallax_effect;
    private float length, startpos;
    public GameObject cam;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallax_effect));
        float dist = (cam.transform.position.x * parallax_effect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) 
            startpos += length;
        else if (temp < startpos - length)
            startpos += length;
    }
}
