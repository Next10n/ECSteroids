using Core.Factories;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class EnemyFactoryComponent :  IComponent
    {
        public IEnemyFactory Value;
    }
}