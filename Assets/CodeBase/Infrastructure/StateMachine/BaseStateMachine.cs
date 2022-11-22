using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public abstract class BaseStateMachine<TState> : IStateMachine where TState : IState
    {
        private Dictionary<Type, TState> _states;
        private TState _currentState;

        protected void InitializeStates()
        {
            _states = CreateStates();
        }
        protected abstract Dictionary<Type, TState> CreateStates();

        public void Enter<T>() where T : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }
    }
}