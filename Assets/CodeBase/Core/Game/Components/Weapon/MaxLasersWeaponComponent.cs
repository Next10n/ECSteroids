using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components.Weapon
{
    [Game, Event(EventTarget.Self)]
    public sealed class MaxLasersWeaponComponent : IComponent
    {
        public int Value;
    }
}