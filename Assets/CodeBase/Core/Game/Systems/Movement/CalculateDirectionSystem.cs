using Entitas;
using UnityEngine;

namespace Core.Game.Systems
{
    public class CalculateDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _directionGroup;
        private readonly Vector2 _worldDirection;

        public CalculateDirectionSystem(Contexts contexts)
        {
            _directionGroup =
                contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.RotationAngle));
            _worldDirection = Vector2.up;
        }

        public void Execute()
        {
            foreach (GameEntity gameEntity in _directionGroup)
            {
                float angleValue = gameEntity.rotationAngle.Value + Vector2.Angle(Vector2.right, _worldDirection);
                float radian = angleValue * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
                gameEntity.ReplaceDirection(direction);
            }
        }
    }
}