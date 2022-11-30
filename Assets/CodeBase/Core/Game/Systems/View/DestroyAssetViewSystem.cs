using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.View
{
    public class DestroyAssetViewSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public DestroyAssetViewSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DestroyEntity);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDestroyAssetView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities)
            {
                GameEntity gameEntity = _contexts.game.CreateEntity();
                gameEntity.AddPoolObject(e.destroyAssetView.Value);
                gameEntity.AddPosition(e.position.Value);
                gameEntity.AddDestroyDelay(1f);
            }
        }
    }
}