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

    [Header ("Select")]
    public magic type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
        }
    }
}
