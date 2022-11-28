using System.Collections.Generic;
using Entitas;

namespace Game.Systems
{
    public class DestroyDeadSystem : ReactiveSystem<GameEntity>
    {
        public DestroyDeadSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities) 
                e.isDestroyEntity = true;
        }
    }
}