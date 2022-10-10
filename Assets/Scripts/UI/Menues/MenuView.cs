using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Other;
using Core.States;
using DG.Tweening;
using UI.Menues;
using UI.Menues.MenuStates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public enum MenuStateEnum
{
    FirstState,
    OptionsMenu,
    GameTypeMenu,
    ExitMenu,
    None
}
public class MenuView : MonoBehaviour
{
    [SerializeField] private MenuBg _menuBg;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private OptionsMenu _optionsMenu;
    [SerializeField] private GameTypeMenu _gameTypeMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private ExitGameMenu _exitGameMenu;
    [SerializeField] private GameObject _blocker;

    private MenuStateEnum _currentState = MenuStateEnum.None;
    private MenuStateEnum _nextState = MenuStateEnum.FirstState;

    private bool canAnimate = true;
    private bool _isMenuScene;
    private Dictionary<MenuStateEnum, IStateMenu> AllStates { get; set; }
    private List<MenuStateEnum> UndoList { get; set; }

    private RunTimeData _runTimeData;
    public Action ChangeBootState;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canAnimate)
        {
            ChangeMenu(); 
        }
    }
    
    public void Init(RunTimeData runTimeData)
    {
        _runTimeData = runTimeData;
        AllStates = new Dictionary<MenuStateEnum, IStateMenu>()
        {
            [MenuStateEnum.FirstState] = new FirstStateMenu(_mainMenu, _pauseMenu),
            [MenuStateEnum.OptionsMenu] = new OptionStateMenu(_optionsMenu),
            [MenuStateEnum.GameTypeMenu] = new GameTypeStateMenu(_gameTypeMenu),
            [MenuStateEnum.ExitMenu] = new ExitStateMenu(_exitGameMenu),
            [MenuStateEnum.None] = new NoneStateMenu(_menuBg, _blocker)
        };
        UndoList = new List<MenuStateEnum>();
        UndoList.Add(_currentState);
        _isMenuScene = SceneManager.GetActiveScene().name == Const.MENU_SCENE;
        
        _mainMenu.SingleMultiButtonAction += SingleMultiButtonDown;
        _mainMenu.OptionsButtonAction += OptionsButtonDown;
        _mainMenu.ExitButtonAction += ExitButtonDown;

        _optionsMenu.BackButtonAction += BackButtonDown;
        
        _gameTypeMenu.simpleOrAdvancedButtonAction += SimpleAdvancedButtonDown;
        _gameTypeMenu.BackButtonAction += BackButtonDown;

        _pauseMenu.BackButtonAction += BackButtonDown;
        _pauseMenu.ExitButtonAction += ExitButtonDown;
        _pauseMenu.LeaveButtonAction += LeaveButtonDown;
        _pauseMenu.OptionsButtonAction += OptionsButtonDown;

        _exitGameMenu.NoButtonAction += BackButtonDown;
        _exitGameMenu.QuitButtonAction += ExitButtonDown;
        
    }

    private void LeaveButtonDown()
    {
        _runTimeData.BootState = BootStateEnum.Menu;
        CloseOnBootChange();
    }

    private void BackButtonDown()
    {
        _nextState = MenuStateEnum.None;
        ChangeMenu();
    }

    public void ExitButtonDown()
    {
        
        Application.Quit();
    }

    private void OptionsButtonDown()
    {
        _nextState = MenuStateEnum.OptionsMenu;
        ChangeMenu();
    }

    private void SingleMultiButtonDown(GameType type)
    {
        _runTimeData.SingleOrMulti = type;
        if (type == GameType.Single)
        {
            _nextState = MenuStateEnum.GameTypeMenu;
            ChangeMenu();
        }
        else
        {
            _runTimeData.BootState = BootStateEnum.Lobby;
            CloseOnBootChange();
        }
    }
    private void SimpleAdvancedButtonDown(GameType type)
    {
        _runTimeData.SimpleOrAdvanced = type;
        _runTimeData.BootState = BootStateEnum.Game;
        CloseOnBootChange();
    }

    public void ChangeMenu(float del = 0f)
    {
        canAnimate = false;
        

        var deley = del;

        if (_nextState != MenuStateEnum.None)
        {
            deley += AllStates[_currentState].Exit(deley);
            _currentState = _nextState;
            deley += AllStates[_currentState].Enter(deley);
            UndoList.Add(_currentState);
            _nextState = MenuStateEnum.None;
            DOVirtual.DelayedCall(deley, () => canAnimate = true);
            return;
        }
        if (UndoList.Count > 2)
        {
            deley += AllStates[_currentState].Exit(deley);
            UndoList.Remove(_currentState);
            _currentState = UndoList.Last();
            deley += AllStates[_currentState].Enter(deley);
            DOVirtual.DelayedCall(deley, () => canAnimate = true);
            return;
        }
        if (UndoList.Count == 2 && _isMenuScene)
        {
            deley += AllStates[_currentState].Exit(deley);
            _currentState = MenuStateEnum.ExitMenu;
            deley += AllStates[_currentState].Enter(deley);
            UndoList.Add(_currentState);
            DOVirtual.DelayedCall(deley, () => canAnimate = true);
            return;
        }

        deley += AllStates[_currentState].Exit(deley);
        if (_currentState != MenuStateEnum.None)
        {
            UndoList.Remove(_currentState);
            _currentState = UndoList.Last();
            deley += AllStates[_currentState].Enter(deley);
            _nextState = MenuStateEnum.FirstState;
            DOVirtual.DelayedCall(deley, () => canAnimate = true);
            return;
        }

        _currentState = _nextState;
        deley += AllStates[_currentState].Enter(deley);
        UndoList.Add(_currentState);
        DOVirtual.DelayedCall(deley, () => canAnimate = true);
    }
    
    private void CloseOnBootChange()
    {
        float del = 0f;
        del += AllStates[_currentState].Exit(del);
        _menuBg.Close(del);
        DOVirtual.DelayedCall(del, () => ChangeBootState?.Invoke());
    }
}
