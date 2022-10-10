using System;
using Core.Data;
using Core.Other;
using Core.Services;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.States
{
    public class PlayGameBootState : BaseStateContainer, IBootState
    {
        
        // public event Action OnStateDone;

        public PlayGameBootState(RunTimeData runTimeData)
            : base(runTimeData) { sceneName = Const.PLAYGAME_SCENE; }

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