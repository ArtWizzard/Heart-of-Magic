using UnityEngine;

[CreateAssetMenu]
public class DataStorage : ScriptableObject
{
    // inventory and progress
    public int runesAmmount;
    public int keysAmmount;
    public int levelsUnlocked;

    // player informations
    public int maxHealth;
    public int maxMana;
    public float manaRegen;

    // magic information
    public int energyBallDamage;
    public int earthBallDamage;
    public float barrierDuration;
    public int beamDamage; 
}
