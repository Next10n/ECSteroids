using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components.Weapon
{
    [Game, Event(EventTarget.Self)]
    public sealed class CurrentLaserRestoreTimeComponent : IComponent
    {
        public float Value;
    }
}