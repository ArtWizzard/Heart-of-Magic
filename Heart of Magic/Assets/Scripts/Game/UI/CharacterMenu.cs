using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.inputString == "i" && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        else if (Input.inputString == "i" && !gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
