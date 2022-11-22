using System;
using System.Collections.Generic;
using Services;

namespace Infrastructure.StateMachine.Gameplay
{
    public class GameplayStateMachine : BaseStateMachine<IGameplayState>, IGameplayStateMachine
    {
        private readonly Contexts _contexts;

        public GameplayStateMachine(Contexts contexts)
        {
            _contexts = contexts;
            DiContainer.Instance.Register<IGameplayStateMachine, GameplayStateMachine>(this);
            InitializeStates();
        }

        protected override Dictionary<Type, IGameplayState> CreateStates()
        {
            return new Dictionary<Type, IGameplayState>()
            {
                [typeof(BootstrapGameplayState)] = new BootstrapGameplayState(_contexts)
            };
        }
    }
}