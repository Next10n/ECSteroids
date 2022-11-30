using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Weapon
{
    public class LaserRestoreSystem : ReactiveSystem<GameEntity>
    {
        public LaserRestoreSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RestoreLaserRequest);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasLaserStorage && entity.hasMaxLasersWeapon;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities)
                if(e.laserStorage.Value < e.maxLasersWeapon.Value)
                    e.ReplaceLaserStorage(e.laserStorage.Value + 1);
        }
    }
}