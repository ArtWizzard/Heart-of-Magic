using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header ("Transform")]
    [SerializeField] private Transform target;

    [Header ("Properities")]
    [SerializeField] private float duration;
    private float actualTime = Mathf.Infinity;

    private void Update()
    {
        transform.position = target.position;
        if (duration < actualTime && gameObject.activeInHierarchy)
        {
            DestroyBarrier();
        }
        actualTime += Time.deltaTime;
    }

    public void SetBarrier()
    {
        actualTime = 0;
        gameObject.SetActive(true);
        
    }

    public void DestroyBarrier()
    {
        gameObject.SetActive(false);
    }
}
