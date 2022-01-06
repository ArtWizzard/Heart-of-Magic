using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_healthBar_behaviour : MonoBehaviour
{
    public Slider Slider;
    public Color Low;       // Barva žádných životů
    public Color High;      // Barva plných životů
    public Vector3 Offset;  // Pozice healthBaru

    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    public void Sethealth(float _health, float _maxHealth)
    {
        Slider.gameObject.SetActive(_health < _maxHealth);
        Slider.value = _health;
        Slider.maxValue = _maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }
}