using Core.Game.Components;
using StaticData;

namespace Core.Factories
{
    public interface IBulletFactory
    {
        GameEntity Create(WeaponType weaponType, GameEntity weapon);
        void Initialize(Contexts contexts);
    }
}