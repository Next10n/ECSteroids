using System;
using System.Collections.Generic;
using Game.Factories;
using Services;
using Services.Input;
using Services.SceneProvider;
using Services.Time;
using Services.View;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IState _currentState;

        public GameStateMachine(DiContainer diContainer, UnityUpdateService updateService, CoroutineRunner coroutineRunner)
        {
            Contexts contexts = new Contexts();
            diContainer.Register<IGameStateMachine, GameStateMachine>(this);
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(diContainer, this, contexts, updateService, coroutineRunner),
                [typeof(LoadGameState)] = new LoadGameState(diContainer.Resolve<ISceneProvider>(), this),
                [typeof(GameLoopState)] = new GameLoopState(diContainer.Resolve<IPlayerFactory>(), contexts,
                    diContainer.Resolve<IViewService>(), diContainer.Resolve<ITimeService>(),
                    diContainer.Resolve<IInputService>(), diContainer.Resolve<ICameraProvider>(),
                    diContainer.Resolve<IEnemyFactory>(), diContainer.Resolve<IUpdateService>())
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}