using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Weapon
{
    public class CreateRestoreLaserRequestSystem : ReactiveSystem<GameEntity>
    {
        public CreateRestoreLaserRequestSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CurrentLaserRestoreTime);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCurrentLaserRestoreTime && entity.hasLaserRestoreTime;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities)
                if(e.currentLaserRestoreTime.Value >= e.laserRestoreTime.Value)
                {
                    e.isRestoreLaserRequest = true;
                    e.RemoveCurrentLaserRestoreTime();
                }        }
    }
}