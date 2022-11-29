using Game.Components;

namespace Game.Systems.WeaponSystems
{
    public interface IBulletFactory
    {
        GameEntity Create(WeaponType weaponType);
        void Initialize(Contexts contexts);
    }
}