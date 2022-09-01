using System;
using System.Collections;
using Core.States;
using UnityEngine;

public interface ICorutine
{
    Coroutine StartCoroutine(IEnumerator enumerator);
}
namespace Core
{
    public class BootStrapper : MonoBehaviour, ICorutine
    {
        public BootStateMachine StateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            StateMachine = new BootStateMachine(this);
        }
    }
}
