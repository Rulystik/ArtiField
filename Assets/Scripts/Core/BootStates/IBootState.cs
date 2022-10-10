using System;

namespace Core.States
{
    public interface IBootState
    {
        public event Action OnStateDoneEvent;
        void Enter();
        float Exit();
    }
}