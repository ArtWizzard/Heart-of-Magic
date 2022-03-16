using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawn : MonoBehaviour
{
    [SerializeField] private Transform position;

    private void Awake()
    {
        transform.position = position.position;
    }
}
