using System;
using System.Collections.Generic;
using Core.Data;
using Core.Services;
using DG.Tweening;

namespace Core.States
{
    public class BootStateMachine 
    {
        private Dictionary<BootStateEnum, IBootState> _states;

        private IBootState currentBootState;
        
        private Factory _factory;
        private RunTimeData _runTimeData;
        
        
        public BootStateMachine()
        {
            _runTimeData = new RunTimeData();

            _states = new Dictionary<BootStateEnum, IBootState>()
            {
                [BootStateEnum.Menu] = new MainMenuBootState(_runTimeData),
                [BootStateEnum.Game] = new PlayGameBootState(_runTimeData),
                [BootStateEnum.Lobby] = new LobbyBootState(_runTimeData)
            };
            BootStateChange();
        }
        
        public void BootStateChange()
        {
            float deley = 0;
            if (currentBootState != null)
            {
                currentBootState.OnStateDoneEvent -= BootStateChange;
                deley = currentBootState.Exit();
            }

            DOVirtual.DelayedCall(deley, () =>
            {
                currentBootState = _states[_runTimeData.BootState];
                currentBootState.OnStateDoneEvent += BootStateChange;
                currentBootState.Enter();
            });
        }

        
    }
}