using System;
using System.Collections;
using Core.States;
using UnityEngine;

namespace Core
{
    public class BootStrapper : MonoBehaviour
    {
        private BootStateMachine _stateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _stateMachine = new BootStateMachine();
        }
    }
}
