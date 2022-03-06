using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [Header ("Enemies")]
    [SerializeField] private GameObject[] ghosts;
    [SerializeField] private float SpawnInterval;
    [Header ("Properities")]
    [SerializeField] private Enemy_health health;


    public bool playerInRagne = false;
    private float delayTime;


    private void Update()
    {
        if ((SpawnInterval < delayTime) && playerInRagne)
        {
            delayTime = 0;
            // Ghosts pooling
            int actual = FindActiveGhost();
            if (actual != -1)
                ghosts[actual].GetComponent<Ghost>().ReSpawn();          // najde neaktivního ducha, vezme skript Ghost a zavolá funkci ReSpawn
        }
        delayTime += Time.deltaTime;
    }

/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Energy_ball")
        {
            health.TakeHit(collision.GetComponent<Energy_fireball>().damage);
        }
        else if (collision.tag == "Artilery_ball")
        {
            health.TakeHit(collision.GetComponent<Bomb_artilery>().damage);
        }
        else if (collision.tag == "Barrier")
        {
            health.TakeHit(collision.GetComponent<Barrier>().damage);
        }
        else if (collision.tag == "Beam")
        {
            health.TakeHit(collision.GetComponent<Beam>().damage);
        }

    }*/

    private int FindActiveGhost()
    {
        for(int i = 0; i < ghosts.Length; i++)
        {
            if(!ghosts[i].activeInHierarchy)
                return i;
        }
        return -1;
    }
}
