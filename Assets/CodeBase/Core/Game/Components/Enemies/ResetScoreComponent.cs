using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components.Enemies
{
    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class ResetScoreComponent : IComponent
    {
        
    }
}