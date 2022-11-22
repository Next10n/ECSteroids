using System;
using System.Collections.Generic;
using Services;
using Services.Coroutine;
using Services.Input;
using Services.SceneProvider;
using Services.Time;
using Services.UpdateService;
using Services.View;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Infrastructure.StateMachine.Game
{
    public class GameStateMachine : BaseStateMachine<IGameState>, IGameStateMachine
    {
        private readonly DiContainer _diContainer;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly UnityUpdateService _updateService;

        public GameStateMachine(DiContainer diContainer, UnityUpdateService updateService, CoroutineRunner coroutineRunner) : base()
        {
            _updateService = updateService;
            _coroutineRunner = coroutineRunner;
            _diContainer = diContainer;
            _diContainer.Register<IGameStateMachine, GameStateMachine>(this);
            InitializeStates();
        }

        protected override Dictionary<Type, IGameState> CreateStates()
        {
            return new Dictionary<Type, IGameState>
            {
                [typeof(BootstrapState)] = new BootstrapState(_diContainer, this, _updateService, _coroutineRunner),
                [typeof(LoadGameState)] = new LoadGameState(_diContainer.Resolve<ISceneProvider>(), this),
                [typeof(GameLoopState)] = new GameLoopState(_diContainer.Resolve<IViewService>(), _diContainer.Resolve<ITimeService>(),
                    _diContainer.Resolve<IInputService>(), _diContainer.Resolve<ICameraProvider>(), _diContainer.Resolve<IUpdateService>())
            };
        }
    }
}