using System;
using Core.Services;
using UnityEngine;

namespace Core.States
{
    public class BootState : BaseState
    {
        private ICorutine _corutine;
        public BootState(BootStateMachine stateMachine, Factory factory, SceneLoader sceneLoader, GlobalParams globalParams,ICorutine coroutine) : base(stateMachine, factory, sceneLoader, globalParams)
        {
            _corutine = coroutine;
        }

        public override void Enter()
        {
            RegisterServices();
            BootStateMachine.SetState<MainMenuState>();
        }

        public override void Exit(Action doStaff)
        {
            
        }


        private void RegisterServices()
        {
            // var services = AllServices.Instance;
            //
            // services.RegisterService(_corutine);
            // // services.RegisterService(new LevelObjectsProvider());
            // services.RegisterService(new Factory());
            // services.RegisterService(new SceneLoader());
            // services.RegisterService(new GlobalParams());
        }
    }
}