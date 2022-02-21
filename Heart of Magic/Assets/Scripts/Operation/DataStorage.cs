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
    public int maxHealth;
    public int maxMana;
    public float manaRegen;

    // magic damage
    public int energyBallDamage;
    public int earthBallDamage;
    public float barrierDuration;
    public int beamDamage; 

    // other
    public bool started = true;
}
