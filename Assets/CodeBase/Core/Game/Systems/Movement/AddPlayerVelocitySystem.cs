using Entitas;
using Infrastructure.Services.Input;
using Infrastructure.Services.Time;
using UnityEngine;

namespace Core.Game.Systems
{
    public class AddPlayerVelocitySystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _playerGroup;
        
        private IInputService _inputService;
        private ITimeService _timeService;

        public AddPlayerVelocitySystem(Contexts contexts)
        {
            _contexts = contexts;
            _playerGroup = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Player, 
                GameMatcher.AccelerationSpeed,
                GameMatcher.Direction));
        }

        public void Initialize()
        {
            _inputService = _contexts.meta.inputService.Value;
            _timeService = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            if (_inputService.AccelerationKeyDown)
                foreach (GameEntity gameEntity in _playerGroup)
                    gameEntity.ReplaceVelocity(CalculateVelocity(gameEntity));
        }

        private Vector2 CalculateVelocity(GameEntity gameEntity)
        {
            Vector2 currentVelocity = gameEntity.hasVelocity ? gameEntity.velocity.Value : Vector2.zero;
            Vector2 addedVelocity = gameEntity.direction.Value * gameEntity.accelerationSpeed.Value * _timeService.DeltaTime;
            Vector2 velocity = currentVelocity + addedVelocity;
            return velocity;
        }
    }
}