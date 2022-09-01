using System;
using System.Collections.Generic;
using Core.Services;
using UI.Menues;

namespace Core.States
{
    public class BootStateMachine
    {
        private IState _currentState;
        private IState _newState;
        private Dictionary<Type, IState> _states;
        
        //No Services
        private Factory _factory;
        private SceneLoader _sceneLoader;
        private GlobalParams _globalParams;
        //
        
        public BootStateMachine(ICorutine coroutine)
        {
            _factory = new Factory();
            _sceneLoader = new SceneLoader(coroutine);
            _globalParams = new GlobalParams();
            
            _states = new Dictionary<Type, IState>()
            {
                //No Services
                // [typeof(BootState)] = new BootState(this, coroutine), 
                [typeof(MainMenuState)] = new MainMenuState(this, _factory, _sceneLoader, _globalParams),
                [typeof(PlayGameState)] = new PlayGameState(this, _factory, _sceneLoader, _globalParams),
                [typeof(MultiplayerLobbyState)] = new MultiplayerLobbyState(this, _factory, _sceneLoader, _globalParams)
            };
            
            SetState<MainMenuState>();
        }
        

        public void SetState<TState>() where TState : IState
        {
            _newState = _states[typeof(TState)];

            if (_currentState == null)
            {
                EnterOnExitDone();
            }
            else
            {
                _currentState.Exit(EnterOnExitDone);
            }
            
        }
        private void EnterOnExitDone()
        {
            _newState.Enter();
            _currentState = _newState;
        }
    }
}