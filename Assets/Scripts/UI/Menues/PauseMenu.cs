using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MenuBase
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button leaveButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    public Action ResumeButtonAction;
    public Action LeaveButtonAction;
    public Action ExitGameAction;
    
    public override void Init()
    {
        InitListButtons();

        leaveButton.onClick.AddListener(LeaveTheGame);
        optionsButton.onClick.AddListener(OptionsButtonDown);
        exitButton.onClick.AddListener(ExitGame);
        resumeButton.onClick.AddListener(BackButtonDown);

        gameObject.SetActive(false);
    }

    private void ExitGame()
    {
        ExitGameAction?.Invoke();
    }

    private void LeaveTheGame()
    {
        LeaveButtonAction?.Invoke();
    }
}
