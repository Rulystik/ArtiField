using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuBase
{
    [SerializeField] private Button singleGameButton;
    [SerializeField] private Button multiGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitGameButton;
    

    
    public Action<GameType> SingleMultiButtonAction;


    public override void Init()
    {
        InitListButtons();
        
        singleGameButton.onClick.AddListener(SingleButtonDown);
        multiGameButton.onClick.AddListener(MultiButtonDown);
        optionsButton.onClick.AddListener(OptionsButtonDown);
        exitGameButton.onClick.AddListener(BackButtonDown);


        gameObject.SetActive(false);
    }
    private void SingleButtonDown()
    {
        SingleMultiButtonAction?.Invoke(GameType.Single);
    }

    private void MultiButtonDown()
    {
        SingleMultiButtonAction?.Invoke(GameType.Multi);
    }

}
