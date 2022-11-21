using Entitas;
using Services.Time;
using UnityEngine;

namespace Game.Systems
{
    public class DecelerationSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _moveGroup;
        
        private ITimeService _timeService;

        public DecelerationSystem(Contexts contexts)
        {
            _contexts = contexts;
            _moveGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Velocity, GameMatcher.Deceleration));
        }

        public void Initialize()
        {
            _timeService = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            foreach (GameEntity gameEntity in _moveGroup)
            {
                if (gameEntity.velocity.Value.magnitude > 0)
                {
                    Vector2 deceleratedVelocity = Vector2.MoveTowards(gameEntity.velocity.Value, Vector2.zero,
                        gameEntity.deceleration.Value * _timeService.DeltaTime);
                    gameEntity.ReplaceVelocity(deceleratedVelocity);
                }
            }            
        }
    }
}