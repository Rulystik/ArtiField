using System;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private GameTypeMenu gameTypeMenu;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private ExitGameMenu exitGameMenu;
    [SerializeField] private OptionsMenu optionsMenu;

    private MenuBehavior menuBehavior;
    private List<MenuBase> allMenuList;
    private GameType simpleAdvType;

    public Action<GameType, GameType> StartGameAction;
    public Action EndGameAction;

    private void Start()
    {
        Init();
        menuBehavior.ActivatorMenu(mainMenu , 0.1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }
    private void Init()
    {
        mainMenu.gameObject.SetActive(true);
        gameTypeMenu.gameObject.SetActive(true);
        allMenuList = new List<MenuBase>();

        allMenuList.Add(mainMenu);
        allMenuList.Add(gameTypeMenu);
        allMenuList.Add(pauseMenu);
        allMenuList.Add(exitGameMenu);
        allMenuList.Add(optionsMenu);

        menuBehavior = new MenuBehavior(allMenuList);

        foreach (var menuBase in allMenuList)
        {
            menuBase.BackAction += Back;
            menuBase.OptionsAction += Options;
        }
        
        mainMenu.SingleMultiButtonAction += SetSimpleAdvGameType;
        gameTypeMenu.simpleOrAvancedGameAction += StartGame;
        pauseMenu.LeaveButtonAction += LeaveGameToMainMenu;
        pauseMenu.ExitGameAction += OpenExitMenu;
        exitGameMenu.QuitButtonAction += QuitGame;


    }
    
    private void OpenExitMenu()
    {
        menuBehavior.ActivatorMenu(exitGameMenu);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void Options()
    {
        menuBehavior.ActivatorMenu(optionsMenu);
    }

    private void LeaveGameToMainMenu()
    {
        menuBehavior.ActivatorMenu(mainMenu);
        EndGameAction?.Invoke();
    }

    private void SetSimpleAdvGameType(GameType type)
    {
        simpleAdvType = type;
        menuBehavior.ActivatorMenu(gameTypeMenu);
    }

    private void StartGame(GameType type)
    {
        menuBehavior.CloseAllMenu();
        StartGameAction?.Invoke(simpleAdvType, type);
    }
    private void Back()
    {
        if (mainMenu.gameObject.activeSelf)
        {
            OpenExitMenu();
        }
        else
        {
            menuBehavior.BackButtonDown();
        }
    }
}
