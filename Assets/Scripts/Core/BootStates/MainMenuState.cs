using System;
using Core.Data;
using Core.Other;
using Core.Services;
using DG.Tweening;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Core.States
{
    public class MainMenuState : BaseState
    {
        public MainMenuState(Factory factory, SceneLoader sceneLoader, BootData globalData) : 
            base(factory, sceneLoader, globalData){}


        public override void Enter()
        {
            SceneLoader.LoadScene(Const.MenuScene, Loaded);
        }

        public override void Exit()
        {
            float delay = UIPreparer.FadeInTransition();
            DOVirtual.DelayedCall(delay, () => OnExitIsDone());
        }
        
        public void Loaded()
        {
            UIPreparer = Factory.GetGameObjectComponent<UIPreparer>();
            var Menu = Factory.GetGameObjectComponent<Menu>(UIPreparer.ScreenArea);
            
            UIPreparer.FadeOutTransition();
            
            Debug.Log("MainMenu is loaded");
        }

    }
}
