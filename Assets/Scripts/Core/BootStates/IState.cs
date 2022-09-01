using System;

namespace Core.States
{
    public interface IState
    {
        void Enter();
        void Exit(Action doStaff);
    }
}