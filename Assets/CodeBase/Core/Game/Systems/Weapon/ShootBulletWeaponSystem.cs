using System.Collections.Generic;
using Core.Factories;
using Core.Game.Components;
using Entitas;
using StaticData;

namespace Core.Game.Systems.Weapon
{
    public class ShootBulletWeaponSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IBulletFactory _bulletFactory;

        public ShootBulletWeaponSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _bulletFactory = _contexts.meta.bulletFactory.Value;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ShootRequest);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isBulletWeapon;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity entity in entities)
            {
                if(entity.isEnabled)
                {
                    GameEntity bullet = _bulletFactory.Create(WeaponType.Bullet, entity);
                    entity.isShootEvent = true;
                    bullet.isBullet = true;
                }
            }
        }
    }
}