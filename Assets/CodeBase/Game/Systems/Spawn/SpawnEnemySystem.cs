using System.Collections.Generic;
using Entitas;
using Game.Factories;

namespace Game.Systems
{
    public class SpawnEnemySystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IEnemyFactory _enemyFactory;
        
        private readonly Contexts _contexts;

        public SpawnEnemySystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _enemyFactory = _contexts.meta.enemyFactory.Value;
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
                    _enemyFactory.Create(e.spawner.Value);
                }
            }
        }
    }
}