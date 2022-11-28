using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Systems.WeaponSystems;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class BulletFactoryComponent :  IComponent
    {
        public IBulletFactory Value;
    }
}