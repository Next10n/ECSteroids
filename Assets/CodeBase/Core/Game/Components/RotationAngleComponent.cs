using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class RotationAngleComponent : IComponent
    {
        public float Value;
    }
}