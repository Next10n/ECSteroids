using System.Collections.Generic;
using Entitas;

namespace Game.Systems
{
    public class KillPlayerOnTrigger2DSystem : ReactiveSystem<GameEntity>
    {
        public KillPlayerOnTrigger2DSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Triggered);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                e.isDead = true;
            }
        }
    }
}