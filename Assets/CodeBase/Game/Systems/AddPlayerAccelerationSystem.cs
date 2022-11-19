using Entitas;
using Services.Input;
using Services.Time;

namespace Game.Systems
{
    public class AddPlayerAccelerationSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _playerGroup;
        
        private IInputService _inputService;
        private ITimeService _timeService;

        public AddPlayerAccelerationSystem(Contexts contexts)
        {
            _contexts = contexts;
            _playerGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.AccelerationSpeed));
        }

        public void Initialize()
        {
            _inputService = _contexts.meta.inputService.Value;
            _timeService = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            if (_inputService.AccelerationKeyDown)
            {
                foreach (GameEntity gameEntity in _playerGroup)
                {
                    float acceleration = gameEntity.hasAcceleration
                        ? gameEntity.acceleration.Value + gameEntity.accelerationSpeed.Value * _timeService.DeltaTime
                        : gameEntity.accelerationSpeed.Value * _timeService.DeltaTime;
                    gameEntity.ReplaceAcceleration(acceleration);
                }
            }
        }
    }
}