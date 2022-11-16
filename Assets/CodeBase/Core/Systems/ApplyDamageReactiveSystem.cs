using System.Collections.Generic;
using Entitas;

namespace Core.Systems
{
    public class ApplyDamageReactiveSystem : ReactiveSystem<GameEntity>
    {
        public ApplyDamageReactiveSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Damage);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDamage && entity.hasHealth;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceHealth(entity.health.Value - entity.damage.Value);
            }
        }
    }
}