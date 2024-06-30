﻿using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootStrapState)] = new BootStrapState(this)
            };
        }

        public void EntryPoint<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}
