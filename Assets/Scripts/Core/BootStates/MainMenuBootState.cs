using System;
using Core.Data;
using Core.Other;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.States
{
    public class MainMenuBootState : BaseStateContainer, IBootState
    {
        public MainMenuBootState(RunTimeData runTimeData) :
            base(runTimeData) { sceneName = Const.MENU_SCENE; }
        
        protected override void Loaded(AsyncOperation operation)
        {
            operation.completed -= Loaded;
            _uiPreparer = _factory.GetGameObjectComponent<UIPreparer>();
            MenuView = _factory.GetGameObjectComponent<MenuView>(_uiPreparer.ScreenArea);
            MenuView.Init(_runTimeData);
            MenuView.ChangeBootState += StateDone;
            
            MenuView.ChangeMenu();
            
            _uiPreparer.FadeOutTransition();
            
        }

    }
}
