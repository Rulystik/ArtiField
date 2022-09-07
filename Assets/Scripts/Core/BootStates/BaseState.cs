using System;
using Core.Data;
using Core.Services;
using UnityEngine.XR;

namespace Core.States
{
    public abstract class BaseState : IState
    {
        protected Factory Factory { get; }
        protected SceneLoader SceneLoader { get; }
        protected BootData GlobalParams { get; }
        
        protected UIPreparer UIPreparer { get; set; }

        public event Action OnChangeState;
        public event Action OnExitDone;

        public BaseState(Factory factory, SceneLoader sceneLoader, BootData globalParams)
        {
            Factory = factory;
            SceneLoader = sceneLoader;
            GlobalParams = globalParams;
        }

        protected void ChangeState()
        {
            OnChangeState?.Invoke();
        }
        protected void OnExitIsDone()
        {
            OnExitDone?.Invoke();
        }
            
        public abstract void Enter();
        public abstract void Exit();
    }
}