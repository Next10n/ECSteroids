using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Core.Game.Systems
{
    public class FollowPositionSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _following;

        public FollowPositionSystem(Contexts contexts) : base(contexts.game)
        {
            _following = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.FollowEntity,
                GameMatcher.Position,
                GameMatcher.Velocity));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity follow in _following)
            foreach(GameEntity e in entities)
            {
                if(e.creationIndex == follow.followEntity.Value && e.isEnabled)
                {
                    float magnitude = follow.velocity.Value.magnitude;
                    Vector2 followingDirection = e.position.Value - follow.position.Value;
                    Vector2 calculatedVelocity = follow.velocity.Value + followingDirection;
                    calculatedVelocity = calculatedVelocity.normalized * magnitude;
                    follow.ReplaceVelocity(calculatedVelocity);
                }
            }
        }
    }
}