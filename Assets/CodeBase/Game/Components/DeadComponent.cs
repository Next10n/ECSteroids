using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Components
{
    [Game, Cleanup(CleanupMode.DestroyEntity), Event(EventTarget.Self)]
    public sealed class DeadComponent : IComponent
    {
    }
}