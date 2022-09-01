using System;
using Core.Services;
using DG.Tweening;
using UnityEngine;

namespace Core.States
{
    public class MainMenuState : BaseState
    {
        private UIPreparer UIPreparer { get; set; }
        public MainMenuState(BootStateMachine bootStateMachine, Factory factory, SceneLoader sceneLoader,
            GlobalParams globalParams) : base(bootStateMachine, factory, sceneLoader, globalParams)
        {
            
        }
        public override void Enter()
        {
            SceneLoader.LoadScene("MainMenu", Loaded);
        }

        public override void Exit(Action doStaff)
        {
            UIPreparer.FadeInTransition(doStaff);
        }

        public void Loaded()
        {
            UIPreparer = Factory.GetGameObjectComponent<UIPreparer>();
            UIPreparer.Init();
            var Menu = Factory.GetGameObjectComponent<Menu>(UIPreparer.ScreenArea);
            Menu.Init(BootStateMachine, GlobalParams);
            
            UIPreparer.FadeOutTransition();
            
            Debug.Log("MainMenu is loaded");
        }
  
    }
}
