using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components.Common
{
    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class TriggeredComponent : IComponent
    {
        public int Value;
    }
}