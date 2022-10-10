using System;
using Core.Data;
using Core.Other;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.States
{
    public class LobbyBootState : BaseStateContainer,  IBootState
    {

        public LobbyBootState(RunTimeData runTimeData) 
            : base(runTimeData) { sceneName = Const.LOBBY_SCENE; }

        protected override void Loaded(AsyncOperation obj)
        {
            obj.completed -= Loaded;
            _uiPreparer = _factory.GetGameObjectComponent<UIPreparer>();
            
            MenuView = _factory.GetGameObjectComponent<MenuView>(_uiPreparer.ScreenArea);
            MenuView.Init(_runTimeData);
            MenuView.ChangeBootState += StateDone;
            
            _uiPreparer.FadeOutTransition();

        }
    }
}