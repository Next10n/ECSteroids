using System.Collections.Generic;
using Core.Factories;
using Core.Game.Components;
using Entitas;
using StaticData;

namespace Core.Game.Systems.Weapon
{
    public class ShootLaserWeaponSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IBulletFactory _bulletFactory;

        public ShootLaserWeaponSystem(Contexts contexts) : base(contexts.game)
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
            return entity.isLaserWeapon && entity.isShootRequest;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity entity in entities)
            {
                GameEntity laser = _bulletFactory.Create(WeaponType.Laser, entity);
                entity.isShootEvent = true;
                laser.isLaser = true;
            }
        }
    }
}