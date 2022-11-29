using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Score
{
    public class ResetScoreSystems : ReactiveSystem<GameEntity>
    {
        public ResetScoreSystems(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ResetScore);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasScore;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities) 
                e.ReplaceScore(0);
        }
    }
}