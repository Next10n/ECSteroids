using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.Services;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class RandomProviderComponent :  IComponent
    {
        public IRandomProvider Value;
    }
}