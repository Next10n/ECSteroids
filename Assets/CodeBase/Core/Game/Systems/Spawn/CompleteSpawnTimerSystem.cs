using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Spawn
{
    public class CompleteSpawnTimerSystem : ReactiveSystem<GameEntity>
    {
        public CompleteSpawnTimerSystem(Contexts contexts) : base(contexts.game)
        {
        }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CurrentSpawnTime);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSpawner && entity.hasSpawnTime;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                if (e.currentSpawnTime.Value >= e.spawnTime.Value)
                {
                    float resetTime = e.currentSpawnTime.Value - e.spawnTime.Value;
                    e.ReplaceCurrentSpawnTime(resetTime);
                    e.isSpawnTimerReady = true;
                }
            }
        }
    }
}