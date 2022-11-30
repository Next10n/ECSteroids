using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Weapon
{
    public class ConsumeLaserStorageSystem : ReactiveSystem<GameEntity>
    {
        public ConsumeLaserStorageSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ShootEvent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isLaserWeapon && entity.hasLaserStorage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities) 
                e.ReplaceLaserStorage(e.laserStorage.Value - 1);
        }
    }
}