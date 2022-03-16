using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoss_spawn : MonoBehaviour
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
                SpawnStopped();
                return;
            }

            Vector3 area = new Vector3(Random.Range(-spawnDistance, spawnDistance), Random.Range(-spawnDistance, spawnDistance), 0);

            ghosts[FindGhost(ghosts)].GetComponent<Ghost>().DistantRespawn(spawnPoint.position + area);
            SoundManager.PlaySound("wizzard_fc");

        } else {
            if (FindGhost(wizGhosts) == -1)
            {
                spawn = false;
                SpawnStopped();
                return;
            }

            Vector3 area = new Vector3(Random.Range(-spawnDistance, spawnDistance), Random.Range(-spawnDistance, spawnDistance), 0);

            wizGhosts[FindGhost(wizGhosts)].GetComponent<Ghost>().DistantRespawn(spawnPoint.position + area);
            SoundManager.PlaySound("wizzard_fc");
        }
    }

    private void Decide()
    {
        if (Random.Range(0,2) != 0)
        {
            type = Type.Ghost;
            if (FindGhost(ghosts) == -1)
                type = Type.WizGhost;
        } else {
            type = Type.WizGhost;
            if (FindGhost(wizGhosts) == -1)
                type = Type.Ghost;
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

    public bool GhostsToSpawn()
    {
        return !(FindGhost(ghosts) == -1 && FindGhost(wizGhosts) == -1);
    }

    public void SetSpawn()
    {
        gameObject.GetComponent<MagicBoss_movement>().FreezeMovement(true);
        Decide();
        spawn = true;
    }

    private void SpawnStopped()
    {
        gameObject.GetComponent<MagicBoss_movement>().FreezeMovement(false);
        gameObject.GetComponent<MagicBoss_controller>().SetNext(true);
    }
}
