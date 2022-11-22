using Entitas;
using Entitas.CodeGeneration.Attributes;
using Game.Factories;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class EnemyFactoryComponent :  IComponent
    {
        public IEnemyFactory Value;
    }
}