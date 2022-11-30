using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Weapon
{
    public class SwitchWeaponSystem : ReactiveSystem<GameEntity>
    {
        public SwitchWeaponSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SwitchWeapon);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isBulletWeapon || entity.isLaserWeapon;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity gameEntity in entities)
            {
                gameEntity.isBulletWeapon = !gameEntity.isBulletWeapon;
                gameEntity.isLaserWeapon = !gameEntity.isLaserWeapon;
            }
        }
    }
}