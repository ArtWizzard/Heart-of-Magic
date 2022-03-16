using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    [SerializeField] private float Hitpoints;
    [SerializeField] private float MaxHitpoints = 5;
    [SerializeField] private Enemy_healthBar HealthBar;

    [Header ("Action")]
    [SerializeField] private bool startWithDeath;
    [SerializeField] private GameObject[] objectsToActive;
    [SerializeField] private GameObject[] objectsToDeactive;
    [SerializeField] private bool instantDrop = false;

    //[SerializeField] private string deathAction;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Collider2D>().tag == "Enemy")
        {
            if (collision.tag == "Energy_ball")
            {
                TakeHit(collision.GetComponent<Energy_fireball>().damage);
            }
            else if (collision.tag == "Artilery_ball")
            {
                TakeHit(collision.GetComponent<Bomb_artilery>().damage);
            }
            else if (collision.tag == "Barrier")
            {
                TakeHit(collision.GetComponent<Barrier>().damage);
            }
            else if (collision.tag == "Beam")
            {
                TakeHit(collision.GetComponent<Beam>().damage);
            }
        }

    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
        //Debug.Log("Damage taken");

        if (Hitpoints <= 0)
        {
            //Destroy(gameObject);
            if (startWithDeath)
                Death();
            gameObject.SetActive(false);
            /*
            if (gameObject.GetComponent<Death>() != null)
                gameObject.GetComponent<Death>().Kill(deathAction);
*/
            if (instantDrop)
                if(gameObject.GetComponent("Item_drop_controller") != null)
                    gameObject.GetComponent<Item_drop_controller>().ItemDrop();

        }
    }

    public void ReLoad()
    {
        Hitpoints = MaxHitpoints;
        HealthBar.Sethealth(Hitpoints,MaxHitpoints);
    }

    private void Death()
    {
        for (int i = 0; i < objectsToActive.Length; i++)
        {
            objectsToActive[i].SetActive(true);
        }
        for (int i = 0; i < objectsToDeactive.Length; i++)
        {
            objectsToDeactive[i].SetActive(false);
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
