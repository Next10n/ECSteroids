using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class RandomProviderComponent :  IComponent
    {
        public IRandomProvider Value;
    }
}