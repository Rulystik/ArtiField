using System;
using Core.Services;
using UnityEngine;

namespace Core.States
{
    public class PlayGameState : BaseState
    {
        private UIPreparer UIPreparer { get; set; }
        public PlayGameState(BootStateMachine bootStateMachine, Factory factory, SceneLoader sceneLoader, GlobalParams globalParams) 
            : base(bootStateMachine, factory, sceneLoader, globalParams) 
        {
            
        }

        public override void Enter()
        {
            SceneLoader.LoadScene("SingleGame", Loaded);
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
            
            Debug.Log("SingleGame is loaded");
        }
    }
}