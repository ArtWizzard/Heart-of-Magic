using UnityEngine;

[CreateAssetMenu]
public class DataStorage : ScriptableObject
{
    // inventory and progress
    public int runesAmmount;
    public int levelsUnlocked;

    // player informations
    public int maxHealth;
    public int maxSpeed;

    // magic information
    public int energyBallDamage;

}
