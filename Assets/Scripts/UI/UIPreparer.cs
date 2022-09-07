using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIPreparer : MonoBehaviour
{
    [SerializeField] private RectTransform _screenArea;
    [SerializeField] private GameObject _blackTransition;
    [SerializeField] private float _speedFading = 0.3f;

    private Image _fadeImage;
    public RectTransform ScreenArea => _screenArea;

    public void OnEnable()
    {
        SetScreenArea();
        _fadeImage = _blackTransition.GetComponent<Image>();
    }
    public float FadeInTransition()
    {
        _blackTransition.SetActive(true);
        _fadeImage.DOFade(1, _speedFading);
        return _speedFading;
    }
    public void FadeOutTransition()
    {
        _fadeImage.DOFade(0, _speedFading).OnComplete(()=> _blackTransition.SetActive(false));
    }

    void SetScreenArea()
    {
        var safeArea = Screen.safeArea;

        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _screenArea.anchorMin = anchorMin;
        _screenArea.anchorMax = anchorMax;
    }
}
