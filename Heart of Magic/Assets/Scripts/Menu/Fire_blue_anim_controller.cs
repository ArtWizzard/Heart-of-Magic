using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_blue_anim_controller : MonoBehaviour
{
    private Animator anim;
    private int rand;
    private float actualTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rand = Random.Range(2,6);
    }

    private void Update()
    {
        if (actualTime > rand)
        {
            actualTime = 0;
            rand = Random.Range(2, 6);
            Change();
        }
        actualTime += Time.deltaTime;
    }

    private void Change()
    {
        if (Random.value > 0.5f)
            anim.SetTrigger("Clock");
        else
            anim.SetTrigger("UnClock");
    }
}
