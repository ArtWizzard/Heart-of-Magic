using UnityEngine;

[CreateAssetMenu]
public class DataStorage : ScriptableObject
{
    // inventory
    public int runesAmmount;
    public int keysAmmount;

    // progress
    public int levelsUnlocked;
    public bool energyUnlocked;
    public bool earthUnlocked;
    public bool barrierUnlocked;
    public bool beamUnlocked;

    // player capability
    public int healthLevel;
    public int manaLevel;
    public int healthRegenLevel;
    public int regenLevel;

    public int maxHealth;
    public int maxMana;
    public float healthRegen;
    public float manaRegen;

    public int healthCost = 3;  // all 3
    public int manaCost = 3;
    public int healthRegenCost = 3;
    public int regenCost = 3;

    // magic damage
    public int energyLevel;
    public int earthLevel;
    public int barrierLevel;
    public int beamLevel;

    public int energyBallDamage;
    public int earthBallDamage;
    public float barrierDuration;
    public int beamDamage; 

    public int energyCost = 1;  // 1, 2, 3, 4
    public int earthCost = 2;
    public int barrierCost = 3;
    public int beamCost = 4;

    // other
    public bool started = true;
    public float volume = 0.5f;
    public float effects = 0.5f;
    public float dialogues = 0.5f;
    public int difficulty = 2;
    public float diffMulti = 0.5f;
}
