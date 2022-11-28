using System.Collections.Generic;
using Entitas;

namespace Game.Systems
{
    public class KillPlayerOnTriggerEnemySystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _enemies;

        public KillPlayerOnTriggerEnemySystem(Contexts contexts) : base(contexts.game)
        {
            _enemies = contexts.game.GetGroup(GameMatcher.Enemy);
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
            foreach(GameEntity enemy in _enemies)
            foreach(GameEntity e in entities)
                if(e.triggered.Value == enemy.creationIndex)
                    e.isDead = true;
        }
    }
}