using System;
using Core.Data;
using Core.Other;
using Core.Services;
using DG.Tweening;
using UnityEngine;

namespace Core.States
{
    public class PlayGameState : BaseState
    {
        private UIPreparer UIPreparer { get; set; }
        // public override event Action<BootStateEnum> OnExitIsDone;
        public PlayGameState(Factory factory, SceneLoader sceneLoader, BootData globalParams) 
            : base(factory, sceneLoader, globalParams) 
        {
            
        }

        public override void Enter()
        {
            SceneLoader.LoadScene(Const.PlayGameScene, Loaded);
        }

        public override void Exit(BootStateEnum state)
        {
            float delay = UIPreparer.FadeInTransition();
            DOVirtual.DelayedCall(delay, () => base.Exit(state));
            // DOVirtual.DelayedCall(delay, () => OnExitIsDone?.Invoke(state));
        }

        public void Loaded()
        {
            UIPreparer = Factory.GetGameObjectComponent<UIPreparer>();
            var Menu = Factory.GetGameObjectComponent<Menu>(UIPreparer.ScreenArea);
            Menu.Init(GlobalParams);
            Menu.ChangeScene += Exit;
            
            UIPreparer.FadeOutTransition();
            
            Debug.Log("SingleGame is loaded");
        }
    }
}