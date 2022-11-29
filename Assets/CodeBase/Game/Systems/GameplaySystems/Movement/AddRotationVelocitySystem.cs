using Entitas;
using Services.Input;
using Services.Time;
using UnityEngine;

namespace Game.Systems
{
    public class AddRotationVelocitySystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _playerGroup;
        
        private IInputService _inputService;
        private ITimeService _timeService;

        public AddRotationVelocitySystem(Contexts contexts)
        {
            _contexts = contexts;
            _playerGroup = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Player, 
                GameMatcher.RotationAngle,
                GameMatcher.AngularSpeed));
        }

        public void Initialize()
        {
            _inputService = _contexts.meta.inputService.Value;
            _timeService = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            foreach (GameEntity gameEntity in _playerGroup)
            {
                float angle = gameEntity.rotationAngle.Value + gameEntity.angularSpeed.Value *
                    -_inputService.HorizontalAxis * _timeService.DeltaTime;
                angle = CutAngle(angle);
                gameEntity.ReplaceRotationAngle(angle);
            }
        }

        private float CutAngle(float angle)
        {
            if (angle > 180)
                angle -= 360;
            if (angle < -180)
                angle += 360;
            return angle;
        }
    }
}