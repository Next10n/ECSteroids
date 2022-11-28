using System;
using System.Collections.Generic;
using Game.Factories;
using Infrastructure.StateMachine.Gameplay;
using Services.SceneProvider;
using Services.StaticData;
using Services.UpdateService;
using Services.Windows;

namespace Infrastructure.StateMachine.Game
{
    public class GameStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public GameStateMachine(IUpdateService updateService, IWindowService windowService, ISceneProvider sceneProvider, IEcsService ecsService,
            IPlayerFactory playerFactory, IEnemyFactory enemyFactory, IWindowFactory windowFactory, IStaticDataService staticDataService)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, staticDataService),
                [typeof(LoadGameState)] = new LoadGameState(sceneProvider, ecsService, updateService, windowService, playerFactory,
                    enemyFactory, windowFactory, this, staticDataService),
                [typeof(RestartState)] = new RestartState(playerFactory, windowService, staticDataService)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }


        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}