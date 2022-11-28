using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class DeadComponent : IComponent
    {
    }
}