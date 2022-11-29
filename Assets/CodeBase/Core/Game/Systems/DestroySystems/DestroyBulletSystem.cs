using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.DestroySystems
{
    public class DestroyBulletSystem : ReactiveSystem<GameEntity>
    {
        public DestroyBulletSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Triggered);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isBullet;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities) 
                e.isDestroyEntity = true;
        }
    }
}