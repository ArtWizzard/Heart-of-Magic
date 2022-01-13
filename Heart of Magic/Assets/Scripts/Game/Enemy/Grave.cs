using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [Header ("Enemies")]
    [SerializeField] private GameObject[] ghosts;
    [SerializeField] private float SpawnInterval;
    private float delayTime;


    private void Update()
    {
        if (SpawnInterval < delayTime)
        {
            delayTime = 0;
            // Ghosts pooling
            int actual = FindActiveGhost();
            if (actual != -1)
                ghosts[actual].GetComponent<Ghost>().ReSpawn();          // najde neaktivního ducha, vezme skript Ghost a zavolá funkci ReSpawn
        }
        delayTime += Time.deltaTime;
    }

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
