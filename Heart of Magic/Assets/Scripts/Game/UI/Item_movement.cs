using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float vertikal;
    [SerializeField] private float vertikal_speed;
    [Header("Properities")]
    public Transform image;
    private Transform rune;

    private void Awake()
    {
        rune = GetComponent<Transform>();
    }

    private void Update()
    {
        float x = rune.position.x;
        float y = rune.position.y + Mathf.Sin(Time.time * vertikal_speed) * vertikal;
        float z = rune.position.z;

        image.position = new Vector3(x, y, z);
    }
}
