using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private float duration;
    private float actualTime = 0;

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (duration < actualTime)
            {
                gameObject.SetActive(false);
                actualTime = 0;

            }
            actualTime += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        gameObject.SetActive(true);
    }
}
