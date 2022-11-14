using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Components
{
    [Cleanup(CleanupMode.RemoveComponent)]
    public class DamageComponent : IComponent
    {
        public float Value;
    }
}