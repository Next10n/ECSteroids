using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components.Common
{
    [Game, Cleanup(CleanupMode.DestroyEntity), Event(EventTarget.Self)]
    public sealed class DestroyEntityComponent : IComponent
    {
    }
}