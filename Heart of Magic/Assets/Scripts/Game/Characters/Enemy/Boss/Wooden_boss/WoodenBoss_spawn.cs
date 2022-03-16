using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type{
    Ghost,
    WizGhost
};

public class WoodenBoss_spawn : MonoBehaviour
{
    [Header ("Monster holders")]
    [SerializeField] private GameObject[] ghosts;
    [SerializeField] private GameObject[] wizGhosts;

    private Type type;

    [Header ("Spawning")]
    [SerializeField] private float spanwDelay;
    [SerializeField] private float spawnDistance;
    [SerializeField] private Transform spawnPoint;
    private float actualTime = Mathf.Infinity;

    private bool spawn;
    private int actualGhost;

    private void Awake()
    {
        spawn = false;
        //actualGhost = 0;
    }

    private void Update()
    {
        if (spawn)
        {
            if (actualTime >= spanwDelay)
            {
                actualTime = 0;
                Spawning();
            }
            actualTime += Time.deltaTime;
        }
    }

    private void Spawning()
    {
        if (type == Type.Ghost)
        {
            if (FindGhost(ghosts) == -1)
            {
                spawn = false;
                gameObject.GetComponent<WoodenBoss_controller>().Float(false);
                return;
            }

            Vector3 area = new Vector3(Random.Range(-spawnDistance, spawnDistance), Random.Range(-spawnDistance, spawnDistance), 0);

            ghosts[FindGhost(ghosts)].GetComponent<Ghost>().DistantRespawn(spawnPoint.position + area);
            SoundManager.PlaySound("wizzard_fc");
        } else {
            if (FindGhost(wizGhosts) == -1)
            {
                spawn = false;
                gameObject.GetComponent<WoodenBoss_controller>().Float(false);
                return;
            }

            Vector3 area = new Vector3(Random.Range(-spawnDistance, spawnDistance), Random.Range(-spawnDistance, spawnDistance), 0);

            wizGhosts[FindGhost(wizGhosts)].GetComponent<Ghost>().DistantRespawn(spawnPoint.position + area);
            SoundManager.PlaySound("wizzard_fc");
        }
    }

    public void SpawnMonsters() // started by animation
    {
        gameObject.GetComponent<WoodenBoss_controller>().Float(false);
        Decide();
        spawn = true;
        //actualGhost = 0;
    }

    private void Decide()
    {
        if (Random.Range(0,2) != 0)
        {
            type = Type.Ghost;
        } else {
            type = Type.WizGhost;
        }
    }

    private int FindGhost(GameObject[] _ghosts)
    {
        for(int i = 0; i < _ghosts.Length; i++)
        {
            if(!_ghosts[i].activeInHierarchy)
                return i;
        }
        return -1;
    }

    public bool AnyGhostDefeated()
    {
        /*
        bool info = true;
        if (FindGhost(ghosts) == -1 && FindGhost(wizGhosts) == -1)
            info = false;
        return info;*/
        return !(FindGhost(ghosts) == -1 && FindGhost(wizGhosts) == -1);
    }
}
