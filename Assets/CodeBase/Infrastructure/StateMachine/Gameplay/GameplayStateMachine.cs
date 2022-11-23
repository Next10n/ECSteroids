using System;
using System.Collections.Generic;
using Game.Factories;
using Services;
using Services.Windows;

namespace Infrastructure.StateMachine.Gameplay
{
    public class GameplayStateMachine : BaseStateMachine<IGameplayState>, IGameplayStateMachine
    {
        private readonly Contexts _contexts;
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowService _windowService;

        public GameplayStateMachine(Contexts contexts, IPlayerFactory playerFactory, IEnemyFactory enemyFactory,
            IWindowService windowService)
        {
            _contexts = contexts;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _windowService = windowService;
            DiContainer.Instance.Register<IGameplayStateMachine, GameplayStateMachine>(this);
            InitializeStates();
        }

        protected override Dictionary<Type, IGameplayState> CreateStates()
        {
            return new Dictionary<Type, IGameplayState>()
            {
                [typeof(BootstrapGameplayState)] = new BootstrapGameplayState(_contexts, _playerFactory, _enemyFactory,
                    _windowService)
            };
        }
    }
}