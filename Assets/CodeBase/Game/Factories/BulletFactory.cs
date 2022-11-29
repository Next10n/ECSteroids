using Game.Components;

namespace Game.Systems.WeaponSystems
{
    public class BulletFactory : IBulletFactory
    {
        private Contexts _contexts;
        
        public void Initialize(Contexts contexts)
        {
            _contexts = contexts;
        }

        public GameEntity Create(WeaponType weaponType)
        {
            GameEntity bullet = _contexts.game.CreateEntity();
            bullet.AddAsset("Bullet");
            bullet.isBullet = true;
            bullet.isTeleportable = true;
            bullet.AddDestroyDelay(5f);
            return bullet;
        }
    }
}