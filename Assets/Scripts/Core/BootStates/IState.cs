using System;

namespace Core.States
{
    public interface IState
    {
        event Action OnChangeState;
        public event Action OnExitDone;
        void Enter();
        void Exit();
    }
}