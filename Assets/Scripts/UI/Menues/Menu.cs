using System;
using Core.States;
using UI.Menues;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private MenuBG _menuBg;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private OptionsMenu _optionsMenu;
    [SerializeField] private GameTypeMenu _gameTypeMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private ExitGameMenu _exitGameMenu;

    private BootStateMachine _bootStateMachine;
    private GlobalParams _globalParams;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "SingleGame")
            {
                _bootStateMachine.SetState<MainMenuState>();
            }
            else
            {
                _bootStateMachine.SetState<PlayGameState>();
            }
        }
    }
    
    public void Init(BootStateMachine stateMachine, GlobalParams globalParams)
    {
        _bootStateMachine = stateMachine;
        _globalParams = globalParams;
        _mainMenu.Init();

        // if (SceneManager.GetActiveScene().name == "MainMenu")
        // {
        //     ActivateMenuPanel();
        // }
        // else
        // {
        //     DeactivateMenuPanel();
        // }
        
        _mainMenu.OptionsButtonAction += SingleMultiButtonAction;
        
    }

    private void SingleMultiButtonAction()
    {
        if (SceneManager.GetActiveScene().name == "SingleGame")
        {
            _bootStateMachine.SetState<MainMenuState>();
        }
        else
        {
            _bootStateMachine.SetState<PlayGameState>();
        }
    }

    private void ActivateMenuPanel()
    {
        _menuPanel.SetActive(true);
    }
    private void DeactivateMenuPanel()
    {
        _menuPanel.SetActive(false);
    }
    

}
