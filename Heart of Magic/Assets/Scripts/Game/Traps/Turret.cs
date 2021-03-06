using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{
    Up,
    Down,
    Right,
    Left
};

public enum Mat{
    Wood,
    Stone,
    Crystal
};

public class Turret : MonoBehaviour
{
    [Header ("Projectiles")]
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Transform firePoint;
    private Vector3 dir;

    [Header ("Select")]
    public Direction direction;
    [SerializeField] private float shootingDelay;

    [Header ("Appearance")]
    public Mat mat;
    [SerializeField] private Sprite wood;
    [SerializeField] private Sprite stone;
    [SerializeField] private Sprite crystal;

    private SpriteRenderer pic;

    private float actualTime = Mathf.Infinity;

    private void Awake()
    {
        actualTime = Random.Range(0, shootingDelay);
        pic = GetComponent<SpriteRenderer>();

        switch(direction)
        {
            case Direction.Up:
                dir = new Vector3(0, 1, 0);
                break;
            case Direction.Down:
                dir = new Vector3(0, -1, 0);
                break;
            case Direction.Right:
                dir = new Vector3(1, 0, 0);
                break;
            case Direction.Left:
                dir = new Vector3(-1, 0, 0);
                break;
        }

        switch (mat)
        {
            case Mat.Wood:
                pic.sprite = wood;
                break;
            case Mat.Stone:
                pic.sprite = stone;
                break;
            case Mat.Crystal:
                pic.sprite = crystal;
                break;
        }
    }

    private void Update()
    {
        if (actualTime >= shootingDelay)
        {
            Shoot();
            actualTime = Random.Range(0,shootingDelay/4);
        }
        actualTime += Time.deltaTime;
    }

    private void Shoot()
    {
        if (FindInactive() != -1)
        {
            projectiles[FindInactive()].transform.position = firePoint.position;
            projectiles[FindInactive()].GetComponent<Enemy_projectile>().SetDirection(dir);
        } 
    }

    private int FindInactive()
    {
        for(int i = 0; i < projectiles.Length; i++)
        {
            if(!projectiles[i].activeInHierarchy)
                return i;
        }
        return -1;  //  vra?? hodnotu z??pornou, jestli??e nem?? ????dn?? voln?? energyball
    }
}
