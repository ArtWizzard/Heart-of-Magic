using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_anim_controller : MonoBehaviour
{
    private Animator anim;
    private int rand;
    private float actualTime;
    private bool animBool = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rand = Random.Range(1,5);
    }

    private void Update()
    {
        if (actualTime > rand)
        {
            actualTime = 0;
            rand = Random.Range(1,5);
            Change();
        }
        actualTime += Time.deltaTime;
    }

    private void Change()
    {
        if (animBool)
        {
            animBool = false;
        }
        else
        {
            animBool = true;
        }
        anim.SetBool("fire_update", animBool);
    }
}
