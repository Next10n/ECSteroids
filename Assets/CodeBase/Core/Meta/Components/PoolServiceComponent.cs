using Core.Game.Systems.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.Services.Pool;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class PoolServiceComponent :  IComponent
    {
        public IPoolService Value;
    }
}