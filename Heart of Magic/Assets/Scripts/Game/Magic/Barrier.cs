using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header ("Transform")]
    [SerializeField] private Transform target;

    [Header ("Properities")]
    //[SerializeField] 
    private float duration;
    [SerializeField] public int damage;
    [SerializeField] private DataStorage storage;
    [SerializeField] private float damageFrequency;
    private float actualFTime = Mathf.Infinity;
    private float actualTime = Mathf.Infinity;

    private CircleCollider2D circleCollider;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        if (target == null)
            target = GameObject.Find("Player").GetComponent<Transform>();

        duration = storage.barrierDuration;
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.position = target.position;
            if (duration < actualTime)
            {
                DestroyBarrier();
            }
            actualTime += Time.deltaTime;

            if (actualFTime > damageFrequency)
            {
                actualFTime = 0;
                circleCollider.enabled = !circleCollider.enabled;
            }
            actualFTime += Time.deltaTime;
        }
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
