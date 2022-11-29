using Entitas;
using Infrastructure.Services.Time;
using UnityEngine;

namespace Core.Game.Systems
{
    public class MoveVelocitySystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _moveGroup;
        private ITimeService _timeServiceValue;

        public MoveVelocitySystem(Contexts contexts)
        {
            _contexts = contexts;
            _moveGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
        }

        public void Initialize()
        {
            _timeServiceValue = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            foreach (GameEntity gameEntity in _moveGroup)
            {
                Vector2 positionValue = gameEntity.position.Value + gameEntity.velocity.Value * _timeServiceValue.DeltaTime;
                gameEntity.ReplacePosition(positionValue);
            }            
        }
    }
}