//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header ("Position")]
    [SerializeField] private Transform player;
    [SerializeField] private float y_delta = 0.7f;
    [SerializeField] private float x_delta;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
        }
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + y_delta, transform.position.z);
    }
}
