using Core.Game.Components;
using Infrastructure.Services.StaticData;
using StaticData;

namespace Core.Factories
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IStaticDataService _staticDataService;
        
        private Contexts _contexts;

        public BulletFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize(Contexts contexts)
        {
            _contexts = contexts;
        }

        public GameEntity Create(WeaponType weaponType, GameEntity weaponEntity)
        {
            WeaponStaticData weaponStaticData = _staticDataService.GetWeaponData(weaponType);
            GameEntity projectile = _contexts.game.CreateEntity();
            projectile.AddPoolObject(weaponStaticData.AssetPath);
            projectile.isTeleportable = weaponStaticData.Teleportable;
            projectile.AddDestroyDelay(weaponStaticData.DestroyTime);
            projectile.AddPosition(weaponEntity.aim.Value.position);
            projectile.AddDirection(weaponEntity.direction.Value);
            projectile.AddVelocity(weaponEntity.direction.Value.normalized * weaponStaticData.ProjectileSpeed);
            projectile.AddRotationAngle(weaponEntity.rotationAngle.Value);
            projectile.AddDestroyAssetView(weaponStaticData.DestroyAsset);
            return projectile;
        }
    }
}