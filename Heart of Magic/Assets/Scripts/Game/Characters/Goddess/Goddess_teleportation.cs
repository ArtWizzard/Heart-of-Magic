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
        //Debug.Log(_place.position.x);
        //Debug.Log(_place.position.y);
        transform.localScale = new Vector3(_direction, 1, 1);
        anim.SetBool("Visible", true);
        TPsound();
        active = true;
    }

    public void HideGoddess()
    {
        anim.SetBool("Visible", false);
        //SoundManager.PlaySound("tp");
        active = false;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void TPsound()
    {
        SoundManager.PlaySound("tp");
    }
}
