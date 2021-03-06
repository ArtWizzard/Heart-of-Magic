using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Mana_bar : MonoBehaviour
{
    [Header ("Database")]
    [SerializeField] DataStorage storage;

    [Header ("Animation")]
    [SerializeField] private RawImage barRawImage;
    [SerializeField] private float animSpeed;
    public Slider slider;
    private float mana;

    private int maxMana;
    private float manaRegen;
    
    private void Awake()
    {
        SetMaxMana(storage.maxMana);
        
        maxMana = storage.maxMana;
        manaRegen = storage.manaRegen;
    }

    private void Update()
    {
        slider.value = mana;
        if (mana < maxMana)
            mana += manaRegen * Time.deltaTime;
        else
            mana = maxMana;

        Rect uvRect = barRawImage.uvRect;
        uvRect.x += animSpeed * Time.deltaTime;
        barRawImage.uvRect = uvRect;;
    }

    public void SetMaxMana(int _mana)
    {
        slider.maxValue = _mana;
        slider.value = 0; //_health;
        mana = 0;
    }

    public bool SpendMana(int _mana)
    {
        if (mana >= _mana)
        {
            mana -= _mana;
            return true;
        } else
        {
            return false;
        }
    }
}