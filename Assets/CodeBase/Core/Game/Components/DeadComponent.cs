using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class DeadComponent : IComponent
    {
    }
}