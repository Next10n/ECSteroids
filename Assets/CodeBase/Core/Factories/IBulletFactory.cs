using Core.Game.Components;

namespace Core.Factories
{
    public interface IBulletFactory
    {
        GameEntity Create(WeaponType weaponType, GameEntity weapon);
        void Initialize(Contexts contexts);
    }
}