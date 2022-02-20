using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goddess_teleportation : MonoBehaviour
{
    private Animator anim;
    private bool deactivateProcess;
    private float stayTime = 1.5f;
    private float actualTime = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (deactivateProcess)
        {
            if (actualTime > stayTime)
            {
                gameObject.SetActive(false);
                deactivateProcess = false;
            }
            actualTime += Time.deltaTime;
        }
    }

    public void ShowGoddess(Transform _place, int _direction)
    {
        transform.position = _place.position;
        transform.localScale = new Vector3(_direction, 1, 1);
        gameObject.SetActive(true);
        anim.SetBool("Visible", true);
    }

    public void HideGoddess()
    {
        anim.SetBool("Visible", false);
        //gameObject.SetActive(false);
        deactivateProcess = true;
        actualTime = 0;
    }
}
