using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ImpactState{
    Falling,
    Flying,
    None
};

public class WoodenBoss_evocate : MonoBehaviour
{
    [Header ("Monster holder")]
    [SerializeField] private GameObject[] evilSeeds;
    
    [Header ("Position")]
    [SerializeField] private Transform[] seedsEvoc;
    [SerializeField] private Transform tp_pos;
    [SerializeField] private float jumpUp;
    [SerializeField] private float gravity;
    [SerializeField] private float speedUp;

    private float fallAcceleration;

    [Header ("Interaction")]
    [SerializeField] private LayerMask groundLayer;

    [Header ("Body damage")]
    [SerializeField] private int damage;

    [Header ("Data storage")]
    [SerializeField] private DataStorage storage;

    private BoxCollider2D boxCollider;
    private ImpactState state;

    private bool active;

    private void Awake()
    {
        state = ImpactState.None;
        boxCollider = GetComponent<BoxCollider2D>();
        active = false;
        //boxcollider.enabled = false; 

        damage = (int)(damage * storage.diffMulti);
    }

     private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            int _damage = damage;
            if (active)
                _damage = damage * 2;
            coll.GetComponent<Player_health>().TakeDamage(_damage);
        }
    }

    private void Update()
    {
        if (active)
        {
            if (state == ImpactState.Falling)
            {
                //transform.position += new Vector3(0, -0.5f, 0) * Time.deltaTime;
                transform.position -= new Vector3(0, fallAcceleration, 0) * Time.deltaTime;
                fallAcceleration += gravity * Time.deltaTime; 

            }
            else if (state == ImpactState.Flying)
            {
                //transform.position = tp_pos.position;
                transform.position = Vector2.MoveTowards(transform.position, tp_pos.position, speedUp * Time.deltaTime);
                if (transform.position == tp_pos.position)
                {
                    gameObject.GetComponent<WoodenBoss_controller>().Float(false);
                    active = false;
                }   
            }

            if (hitGround() && state == ImpactState.Falling)
            {
                //transform.position = tp_pos.position;
                state = ImpactState.Flying;
                Evocate();
                SoundManager.PlaySound("impact");
            }
        }
    }

    public void SetImpact()
    {
        gameObject.GetComponent<WoodenBoss_controller>().Float(false);
        tp_pos = gameObject.GetComponent<WoodenBoss_movement>().future;
        state = ImpactState.Falling;
        fallAcceleration = -jumpUp;
        active = true;
        //boxCollider.enabled = true; // damage incraese
    }

    private bool hitGround()
    {
        RaycastHit2D raycastHit =   Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void Evocate()  // works
    {
        for (int i = 0; i < seedsEvoc.Length; i ++)
        {
            if (FindFreeEviSevi() == -1)
                return;
            else
            {
                evilSeeds[FindFreeEviSevi()].transform.position = seedsEvoc[i].position;
                evilSeeds[FindFreeEviSevi()].SetActive(true);
            }

        }
    }

    private int FindFreeEviSevi()
    {
        for(int i = 0; i < evilSeeds.Length; i++)
        {
            if(!evilSeeds[i].activeInHierarchy)
                return i;
        }
        return -1;
    }

    public bool AnySeedsDefeated()
    {
        return FindFreeEviSevi() == -1;
    }
}
