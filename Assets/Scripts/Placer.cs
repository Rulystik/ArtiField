using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Placer : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int count;
    [SerializeField] private int ID;

    public Action<Placer> PlacerAction;

    public int Count
    {
        get => count;
        set
        {
            count = value;
            text.text = count.ToString();
        }
    }

    private void Start()
    {
        text.text = count.ToString();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (count != 0)
        {
            PlacerAction?.Invoke(this);
        }
    }
}
