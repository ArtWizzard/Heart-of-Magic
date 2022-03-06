//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header ("Position")]
    [SerializeField] private Transform player;
    //[SerializeField] 
    private float smoothSpeed = 4;
    [SerializeField] private float y_delta = 0.7f;
    [SerializeField] private float x_delta;
    private Vector3 offset;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
        }

        offset = new Vector3(x_delta, y_delta, 0);
    }

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        //transform.position = new Vector3(player.position.x, player.position.y + y_delta, transform.position.z);
        transform.position = smoothedPosition - new Vector3(0, 0, 10);
    }
}
