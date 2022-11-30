using Entitas;
using Infrastructure.Services.Time;

namespace Core.Game.Systems.Weapon
{
    public class RestoreLaserTimerSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _restoreLaserTime;
        
        private ITimeService _timeService;

        public RestoreLaserTimerSystem(Contexts contexts)
        {
            _contexts = contexts;
            _restoreLaserTime = _contexts.game.GetGroup(GameMatcher.CurrentLaserRestoreTime);
        }

        public void Initialize()
        {
            _timeService = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            foreach(GameEntity gameEntity in _restoreLaserTime)
                gameEntity.ReplaceCurrentLaserRestoreTime(gameEntity.currentLaserRestoreTime.Value + _timeService.DeltaTime);
        }
    }
}