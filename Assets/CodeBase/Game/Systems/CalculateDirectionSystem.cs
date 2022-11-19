using Entitas;
using UnityEngine;

namespace Game.Systems
{
    public class CalculateDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _directionGroup;

        public CalculateDirectionSystem(Contexts contexts)
        {
            _directionGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.RotationAngle));
        }

        public void Execute()
        {
            foreach (GameEntity gameEntity in _directionGroup)
            {
                float angleValue = gameEntity.rotationAngle.Value;
                Vector2 direction = new Vector2(Mathf.Sin(angleValue), Mathf.Cos(angleValue)) ;
                gameEntity.ReplaceDirection(direction);
            }
        }
    }
}