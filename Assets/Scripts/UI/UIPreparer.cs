using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIPreparer : MonoBehaviour
{
    [SerializeField] private GameObject _screenArea;
    [SerializeField] private GameObject _blackTransition;
    public Transform ScreenArea { get; private set; }

    public void Init()
    {
        ScreenArea = _screenArea.transform;
        UpdateScreenArea();
    }
    public void FadeInTransition(Action doStaff)
    {
        _blackTransition.SetActive(true);
        var image = _blackTransition.GetComponent<Image>();
        image.DOFade(0, 0);
        image.DOFade(1, 0.3f).OnComplete(()=> doStaff?.Invoke());

    }
    public void FadeOutTransition()
    {
        var image = _blackTransition.GetComponent<Image>();
        image.DOFade(1, 0);
        image.DOFade(0, 0.3f).OnComplete(()=> _blackTransition.SetActive(false));
    }

    void UpdateScreenArea()
    {
        var safeArea = Screen.safeArea;
        var areaRect = _screenArea.GetComponent<RectTransform>();

        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        areaRect.anchorMin = anchorMin;
        areaRect.anchorMax = anchorMax;
    }
}
