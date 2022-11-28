using System.Collections.Generic;
using Entitas;

namespace Game.Systems.WeaponSystems
{
    public class DestroyDelaySystem : ReactiveSystem<GameEntity>
    {
        public DestroyDelaySystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DestroyTimer);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDestroyDelay;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities)
            {
                if(e.destroyTimer.Value >= e.destroyDelay.Value)
                    e.isDestroyEntity = true;
            }
        }
    }
}