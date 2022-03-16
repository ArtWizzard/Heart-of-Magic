using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] public InventoryManager IM;

    [Header("Door")]
    [SerializeField] public SpriteRenderer backDoors;
    [SerializeField] public GameObject doors;
    [SerializeField] public SpriteRenderer frontDoors;
    [SerializeField] private Sprite backOpened;
    [SerializeField] private Sprite frontOpened;
    [SerializeField] private Sprite backClosed;
    [SerializeField] private Sprite door;
    [SerializeField] private Sprite frontClosed;
    private bool inside;
    private bool open = false;

    [Header("Properities")]
    [SerializeField] private int keys_needed;

    private void Awake()
    {
        if (IM == null)
            IM = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inside)
        {
            //  payment
            IM.Pick("Key", -keys_needed);

            //  mechanics
            backDoors.sprite = backOpened;
            doors.SetActive(false);
            frontDoors.sprite = frontOpened;

            //  state
            open = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int keyAmmount = IM.GetComponent<InventoryManager>().keys;

        if(collision.tag == "Player" && keyAmmount - keys_needed >= 0  && !open)
        {
            inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            inside = false;
    }
}
