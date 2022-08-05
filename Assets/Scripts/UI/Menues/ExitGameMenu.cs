using System;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameMenu : MenuBase
{
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    public Action QuitButtonAction;
    public override void Init()
    {
        InitListButtons();
        
        yesButton.onClick.AddListener(YesButtonDown);
        noButton.onClick.AddListener(BackButtonDown);
        
        gameObject.SetActive(false);
        
    }
    private void YesButtonDown()
    {
        QuitButtonAction?.Invoke();
    }
}
