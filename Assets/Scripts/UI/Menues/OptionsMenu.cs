using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MenuBase
{
    [SerializeField] private Button backButton;
    public override void Init()
    {
        InitListButtons();
        backButton.onClick.AddListener(BackButtonDown);
        gameObject.SetActive(false);
    }
}
