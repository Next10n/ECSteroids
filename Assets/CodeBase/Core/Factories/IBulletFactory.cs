using Core.Game.Components;

namespace Core.Factories
{
    public interface IBulletFactory
    {
        GameEntity Create(WeaponType weaponType);
        void Initialize(Contexts contexts);
    }
}