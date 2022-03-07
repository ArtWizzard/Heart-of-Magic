using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    [Header ("Health")]
    public int maxHealth;
    public float currentHealth;
    private float healthRegen;
    //private bool dead;

    [Header ("Regeneration")]
    [SerializeField] private float timeToRegen;
    private float recoveryTime = Mathf.Infinity;

    [Header ("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Storages")]
    [SerializeField] private DataStorage dataStorage;
    
    [Header("References")]
    public Health_bar health_bar;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        healthRegen = dataStorage.healthRegen;
        maxHealth = dataStorage.maxHealth;
        ResetHealth();
    }

    private void Update()
    {
        if (recoveryTime >= timeToRegen)
        {
            if (currentHealth < maxHealth)
            {
                if (maxHealth - currentHealth >= healthRegen)
                {
                    currentHealth += healthRegen * Time.deltaTime;
                } else
                {
                    currentHealth = (float)maxHealth;
                }
            }
            Draw();
        }
        recoveryTime += Time.deltaTime;
    }
    
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        health_bar.SetMaxHealth(maxHealth); 
    }
    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if(currentHealth <= 0)
            {
                currentHealth = 0;
                //dead = true;
                //Debug.Log("Current health: " + currentHealth.ToString());
                //FindObjectOfType<LevelManager>().Respawn();
                FindObjectOfType<GameManager>().EndGame();
            }

        StartCoroutine(Invunerability());
        SoundManager.PlaySound("wizzard_hit");
        Draw();
        recoveryTime = 0;
    }

    public void Kill()
    {
        currentHealth = 0;
    }

    private IEnumerator Invunerability()
    {
        Invicibly(true);
        //Invunerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.8f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Invicibly(false);

    }

    private void Invicibly(bool _set)
    {
        Physics2D.IgnoreLayerCollision(10, 13, _set);
        Physics2D.IgnoreLayerCollision(10, 12, _set);
        Physics2D.IgnoreLayerCollision(10, 15, _set);
    }

    private void Draw()
    {
        health_bar.SetHealth((int)currentHealth);
    }
}
