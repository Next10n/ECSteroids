using System.Collections.Generic;
using Entitas;
using Game.Factories;

namespace Game.Systems.Spawn
{
    public class SpawnEnemySystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IEnemyFactory _enemyFactory;

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
            return context.CreateCollector(GameMatcher.SpawnTimerReady);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSpawner;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                _enemyFactory.Create(e.spawner.Value);
            }
        }
    }
}