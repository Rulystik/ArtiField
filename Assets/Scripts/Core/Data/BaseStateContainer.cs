using System;
using Core.Services;
using Core.Other;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Data
{
    public abstract class BaseStateContainer
    {
        protected string sceneName;
        protected Factory _factory;
        protected RunTimeData _runTimeData;
        protected UIPreparer _uiPreparer;
        protected MenuView MenuView;
        
        public event Action OnStateDoneEvent;

        public BaseStateContainer(RunTimeData runTimeData)
        {
            _factory = new Factory();
            _runTimeData = runTimeData;
        }
        
        public virtual void Enter()
        {
            SceneManager.LoadSceneAsync(sceneName).completed += Loaded;
        }
        public virtual float Exit()
        {
            MenuView.ChangeBootState -= StateDone;
            float deley = _uiPreparer.FadeInTransition();
            return deley;
        }

        protected abstract void Loaded(AsyncOperation obj);
        protected void StateDone()
        {
            OnStateDoneEvent?.Invoke();
        }
            
    }
}