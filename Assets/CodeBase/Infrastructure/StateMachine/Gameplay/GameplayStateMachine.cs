using System;
using System.Collections.Generic;
using Game.Factories;
using Services;

namespace Infrastructure.StateMachine.Gameplay
{
    public class GameplayStateMachine : BaseStateMachine<IGameplayState>, IGameplayStateMachine
    {
        private readonly Contexts _contexts;
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;

        public GameplayStateMachine(Contexts contexts, IPlayerFactory playerFactory, IEnemyFactory enemyFactory)
        {
            _contexts = contexts;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            DiContainer.Instance.Register<IGameplayStateMachine, GameplayStateMachine>(this);
            InitializeStates();
        }

        protected override Dictionary<Type, IGameplayState> CreateStates()
        {
            return new Dictionary<Type, IGameplayState>()
            {
                [typeof(BootstrapGameplayState)] = new BootstrapGameplayState(_contexts, _playerFactory, _enemyFactory)
            };
        }
    }
}