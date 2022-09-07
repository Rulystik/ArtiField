using System;
using Core.Data;
using Core.Other;
using Core.States;
using UI.Menues;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private MenuBG _menuBg;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private OptionsMenu _optionsMenu;
    [SerializeField] private GameTypeMenu _gameTypeMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private ExitGameMenu _exitGameMenu;
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }
    
    public void OnEnable()
    {

        _mainMenu.SingleMultiButtonAction += SingleMultiButtonDown;
        _gameTypeMenu.simpleOrAvancedButtonAction += SimpleAdvancedButtonDown;
    }

    private void SingleMultiButtonDown(GameType type)
    {
        
    }
    private void SimpleAdvancedButtonDown(GameType type)
    {
        
    }

    

}
