using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum magic{
    energy,
    earth,
    barrier,
    beam
};

public class Magic_receiving : MonoBehaviour
{
    [Header ("Storage")]
    [SerializeField] private DataStorage dataStorage;
    public bool unlocked = false;

    [Header ("Select")]
    public magic type;

    private void Awake()
    {
        switch(type)
        {
            case magic.energy:
                unlocked = dataStorage.energyUnlocked;
                break;
            case magic.earth:
                unlocked = dataStorage.earthUnlocked;
                break;
            case magic.barrier:
                unlocked = dataStorage.barrierUnlocked;
                break;
            case magic.beam:
                unlocked = dataStorage.beamUnlocked;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !unlocked)
        {
            switch(type)
            {
                case magic.energy:
                    dataStorage.energyUnlocked = true;
                    break;
                case magic.earth:
                    dataStorage.earthUnlocked = true;
                    break;
                case magic.barrier:
                    dataStorage.barrierUnlocked = true;
                    break;
                case magic.beam:
                    dataStorage.beamUnlocked = true;
                    break;
            }
            unlocked = true;
        }
    }
}
