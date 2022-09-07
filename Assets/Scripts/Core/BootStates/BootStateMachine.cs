using System;
using System.Collections.Generic;
using Core.Data;
using Core.Services;

namespace Core.States
{
    public class BootStateMachine 
    {
        private Dictionary<Type, IState> _states;

        private IState _currentState;
        private IState _nextState;
        
        private Factory _factory;
        private SceneLoader _sceneLoader;
        private BootData _globalData;
        //
        
        public BootStateMachine(ICorutine coroutine)
        {
            _factory = new Factory();
            _sceneLoader = new SceneLoader(coroutine);
            _globalData = new BootData();

            _states = new Dictionary<Type, IState>()
            {
                [typeof(MainMenuState)] = new MainMenuState(_factory, _sceneLoader, _globalData),
                [typeof(PlayGameState)] = new PlayGameState(_factory, _sceneLoader, _globalData),
                [typeof(MultiplayerLobbyState)] = new MultiplayerLobbyState(_factory, _sceneLoader, _globalData)
            };
            foreach (var state in _states)
            {
                state.Value.OnChangeState += StateChange;
                state.Value.OnExitDone += EnterState;
            }
            
            StateChange();
            EnterState();
        }
        
        public void StateChange()
        {
            switch (_globalData.BootState)
            {
                case BootStateEnum.Game :
                    SetNextState<PlayGameState>();
                    break;
                case BootStateEnum.Menu :
                    SetNextState<MainMenuState>();
                    break;
                case BootStateEnum.Lobby :
                    SetNextState<MultiplayerLobbyState>();
                    break;
            }
            _currentState?.Exit();
        }

        private void SetNextState<TState>() where TState : IState
        {
            _nextState = _states[typeof(TState)];
        }
        private void EnterState()
        {
            _currentState = _nextState;
            _currentState.Enter();
        }
        
    }
}