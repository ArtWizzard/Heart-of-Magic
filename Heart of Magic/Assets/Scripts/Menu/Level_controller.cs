using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum nameState{
    Level_0,
    Level_1,
    Level_2,
    Level_3,
    Level_4,
    Level_5,
    Level_6,
    Level_7,
    Level_8,
    Level_9,
    Level_10
};

public class Level_controller : MonoBehaviour
{
    Dictionary<nameState, string> translation = new Dictionary<nameState, string>(){
        {nameState.Level_0, "Level_0"},
        {nameState.Level_1, "Level_1"},
        {nameState.Level_2, "Level_2"},
        {nameState.Level_3, "Level_3"},
        {nameState.Level_4, "Level_4"},
        {nameState.Level_5, "Level_5"},
        {nameState.Level_6, "Level_6"},
        {nameState.Level_7, "Level_7"},
        {nameState.Level_8, "Level_8"},
        {nameState.Level_9, "Level_9"},
        {nameState.Level_10, "Level_10"},
    };


    [Header ("Select")]
    [SerializeField] private GameObject manager;
    public nameState name;
    public bool Locked = true;
    [Header ("Appearance")]
    [SerializeField] private Sprite locked;
    [SerializeField] private Sprite locked_selected;
    [SerializeField] private Sprite unlocked;
    [SerializeField] private Sprite unlocked_selected;

    private SpriteRenderer pic;

    private void Awake()
    {
        pic = GetComponent<SpriteRenderer>();

        if (Locked == true)
        {
            pic.sprite = locked;
        } else if (Locked == false)
        {
            pic.sprite = unlocked;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.GetComponent<LevelSelector>().Select(translation[name]);
    }

    public void Change(string _name)
    {
        if (Locked == true)
        {
            if(_name == translation[name])
            {
                pic.sprite = locked_selected;
            } else
            {
                pic.sprite = locked;
            }

        } else if (Locked == false)
        {
            if(_name == translation[name])
            {
                pic.sprite = unlocked_selected;
            } else
            {
                pic.sprite = unlocked;
            }
        }
    }
}
