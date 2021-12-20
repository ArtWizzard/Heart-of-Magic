using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [Header ("Box Transform")]
    [SerializeField] private float space;
    [SerializeField] private RectTransform rectTransform;
    private float width;
    private float height;
    [Header ("Canvas Transform")]
    [SerializeField] RectTransform canvas;

    private void Start()
    {
        //rectTransform.position = new Vector3(canvas.position.x, canvas.position.y, canvas.position.z);
        height = canvas.sizeDelta.y / 8;
        width = canvas.sizeDelta.x - space;
        rectTransform.sizeDelta = new Vector2(width, height);
    }
}
