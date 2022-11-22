using Entitas;
using Services.Time;

namespace Game.Systems
{
    public class SpawnTimerSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _timerGroup;
        
        private ITimeService _timeService;

        public SpawnTimerSystem(Contexts contexts)
        {
            _contexts = contexts;
            _timerGroup = _contexts.game.GetGroup(GameMatcher.CurrentSpawnTime);
        }

        public void Initialize()
        {
            _timeService = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            foreach (GameEntity gameEntity in _timerGroup)
            {
                float time = gameEntity.currentSpawnTime.Value + _timeService.DeltaTime;
                gameEntity.ReplaceCurrentSpawnTime(time);
            }
        }
    }
}