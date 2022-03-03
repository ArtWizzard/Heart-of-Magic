using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    [Header ("Health")]
    private int maxtHealth;
    public int currentHealth;
    //private bool dead;

    [Header ("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Storages")]
    [SerializeField] private DataStorage dataStorage;
    
    [Header("References")]
    public Health_bar health_bar;

    void Start()
    {
        ResetHealth();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    
    public void ResetHealth()
    {
        currentHealth = dataStorage.maxHealth;
        health_bar.SetMaxHealth(dataStorage.maxHealth); 
    }
    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if(currentHealth <= 0)
            {
                currentHealth = 0;
                //dead = true;
                //Debug.Log("Current health: " + currentHealth.ToString());
                FindObjectOfType<LevelManager>().Respawn();
            }

        StartCoroutine(Invunerability());
        SoundManager.PlaySound("wizzard_hit");
        health_bar.SetHealth(currentHealth);
    }

    public void Kill()
    {
        currentHealth = 0;
        FindObjectOfType<LevelManager>().Respawn();
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 13, true);
        //Invunerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.8f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 13, false);

    }
}
