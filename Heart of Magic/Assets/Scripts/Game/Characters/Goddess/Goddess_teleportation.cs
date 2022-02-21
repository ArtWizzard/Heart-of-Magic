using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goddess_teleportation : MonoBehaviour
{
    private Animator anim;
    public bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowGoddess(Transform _place, int _direction)
    {
        gameObject.SetActive(true);
        transform.position = _place.position;
        transform.localScale = new Vector3(_direction, 1, 1);
        anim.SetBool("Visible", true);
        active = true;
    }

    public void HideGoddess()
    {
        anim.SetBool("Visible", false);
        
        active = false;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
