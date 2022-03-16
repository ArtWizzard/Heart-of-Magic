using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileResetter : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;

    public void ResetProjectiles()
    {
        for (int i = 0; i < projectiles.Length; i ++)
        {
            projectiles[i].SetActive(false);
        }
    }
}
