using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.DestroySystems
{
    public class DestroyEnemySystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _bullets;

        public DestroyEnemySystem(Contexts contexts) : base(contexts.game)
        {
            _bullets = contexts.game.GetGroup(GameMatcher.Bullet);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Triggered);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity bullet in _bullets)
            foreach(GameEntity e in entities)
            {
                if(bullet.creationIndex == e.triggered.Value)
                    e.isDestroyEntity = true;
            }
        }
    }
}