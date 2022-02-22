using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goddess_levitating : MonoBehaviour
{

    [Header ("Movement")]
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 1f;
    private bool fly = false;
    private float deltaTime;
 
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
 
    private void Transfer () {
        posOffset = transform.position;
    }

    private void Update () {
        if (fly)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin ((deltaTime - Time.fixedTime) * Mathf.PI * frequency) * amplitude;
    
            transform.position = tempPos;
        }
    }

    private void SetFloating()
    {
        fly = true;
        Transfer();
        deltaTime = Time.fixedTime;
    }

    private void UnsetFloating()
    {
        fly = false;
    }
}
