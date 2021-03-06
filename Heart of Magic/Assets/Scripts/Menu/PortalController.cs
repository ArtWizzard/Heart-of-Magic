using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [Header ("Scene")]
    [SerializeField] private string target; 
    private bool inside;

    private AudioSource audi;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inside)
            SceneManager.LoadScene(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inside = true;
            anim.SetBool("inside", true);
            audi.mute = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inside = false;
            anim.SetBool("inside", false);
            audi.mute = true;
        }
    }
}
