using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private int maxtHealth = 100;
    [SerializeField] private int startHealth = 100;
    public int currentHealth;
    private bool dead;

    [Header ("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    public Health_bar health_bar;

    void Start()
    {
        currentHealth = startHealth;
        health_bar.SetMaxHealth(maxtHealth);
        spriteRend = GetComponent<SpriteRenderer>();
    }
    
    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if(currentHealth <= 0)
            {
                currentHealth = 0;
                dead = true;
            }
        StartCoroutine(Invunerability());

        health_bar.SetHealth(currentHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //Invunerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.8f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }
}
