using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Weapon
{
    public class CreateRestoreTimerSystem : ReactiveSystem<GameEntity>
    {
        public CreateRestoreTimerSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.LaserStorage);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasLaserRestoreTime && entity.hasCurrentLaserRestoreTime == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity gameEntity in entities)
                if(gameEntity.laserStorage.Value < gameEntity.maxLasersWeapon.Value)
                    gameEntity.AddCurrentLaserRestoreTime(0f);
        }
    }
}