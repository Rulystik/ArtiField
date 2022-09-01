using System;
using Core.Services;

namespace Core.States
{
    public abstract class BaseState : IState
    {
        protected BootStateMachine BootStateMachine { get; }
        protected Factory Factory { get; }
        protected SceneLoader SceneLoader { get; }
        protected GlobalParams GlobalParams { get; }

        public BaseState(BootStateMachine stateMachine, Factory factory, SceneLoader sceneLoader, GlobalParams globalParams)
        {
            BootStateMachine = stateMachine;
            Factory = factory;
            SceneLoader = sceneLoader;
            GlobalParams = globalParams;
        }

        public abstract void Enter();
        public abstract void Exit(Action doStaff);
        

    }
}