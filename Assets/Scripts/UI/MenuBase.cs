using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuBase : MonoBehaviour
{
    public List<RectTransform> AllObjectsRect { get ;} = new List<RectTransform>();
    public Action BackAction;
    public Action OptionsAction;

    public abstract void Init();

    public void ActiveOn()
    {
        gameObject.SetActive(true);
    }

    public void ActiveOff()
    {
        gameObject.SetActive(false);
    }
    public void InitListButtons()
    {
        foreach (Transform obj in transform)
        {
            AllObjectsRect.Add(obj.GetComponent<RectTransform>());
        }
    }
    public void BackButtonDown()
    {
        BackAction?.Invoke();
    }

    public void OptionsButtonDown()
    {
        OptionsAction?.Invoke();
    }
}
