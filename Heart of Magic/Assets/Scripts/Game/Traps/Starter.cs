using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [Header ("Bucket")]
    [SerializeField] private GameObject[] bucket;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i].SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
