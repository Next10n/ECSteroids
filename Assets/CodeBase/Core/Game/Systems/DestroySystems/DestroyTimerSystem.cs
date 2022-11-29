using Entitas;
using Infrastructure.Services.Time;

namespace Core.Game.Systems.DestroySystems
{
    public class DestroyTimerSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _delayDestroyGroup;
        private ITimeService _timeService;

        public DestroyTimerSystem(Contexts contexts)
        {
            _contexts = contexts;
            _delayDestroyGroup = _contexts.game.GetGroup(GameMatcher.DestroyDelay);
        }
        
        public void Initialize()
        {
            _timeService = _contexts.meta.timeService.Value;
        }

        public void Execute()
        {
            foreach(GameEntity gameEntity in _delayDestroyGroup)
            {
                if(gameEntity.hasDestroyTimer)
                {
                    float destroyTimer = gameEntity.destroyTimer.Value + _timeService.DeltaTime;
                    gameEntity.ReplaceDestroyTimer(destroyTimer);
                }
                else
                {
                    gameEntity.AddDestroyTimer(_timeService.DeltaTime);
                }
            }
        }
    }
}