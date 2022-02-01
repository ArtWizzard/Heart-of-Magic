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
    Dictionary<nameState, int> translation = new Dictionary<nameState, int>(){
        {nameState.Level_0, 0},
        {nameState.Level_1, 1},
        {nameState.Level_2, 2},
        {nameState.Level_3, 3},
        {nameState.Level_4, 4},
        {nameState.Level_5, 5},
        {nameState.Level_6, 6},
        {nameState.Level_7, 7},
        {nameState.Level_8, 8},
        {nameState.Level_9, 9},
        {nameState.Level_10, 10},
    };

    [Header ("Select")]
    [SerializeField] private GameObject manager;
    public nameState name;
    public bool Locked = true;
    private string level;

    [Header ("Appearance")]
    [SerializeField] private Sprite locked;
    [SerializeField] private Sprite locked_selected;
    [SerializeField] private Sprite unlocked;
    [SerializeField] private Sprite unlocked_selected;

    [Header ("Storage")]
    [SerializeField] private DataStorage dataStorage;

    private SpriteRenderer pic;

    private void Awake()
    {
        //  locked/unlocked
        Locked = true;
        if (translation[name] <= dataStorage.levelsUnlocked)
            Locked = false;

        //  visualization
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
        level = "Level_" + translation[name].ToString();
        manager.GetComponent<LevelSelector>().Select(level, Locked);
    }

    public void Change(string _name)
    {
        level = "Level_" + translation[name].ToString();

        if (Locked == true)
        {
            if(_name == level)
            {
                pic.sprite = locked_selected;
            } else
            {
                pic.sprite = locked;
            }

        } else if (Locked == false)
        {
            if(_name == level)
            {
                pic.sprite = unlocked_selected;
            } else
            {
                pic.sprite = unlocked;
            }
        }
    }
}
