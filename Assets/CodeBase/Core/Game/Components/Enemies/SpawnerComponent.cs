using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components.Enemies
{
    public enum EnemyType
    {
        Asteroid = 0,
        Ufo = 1,
        AsteroidFragments = 2
    }
    
    [Game]
    public sealed class SpawnerComponent : IComponent
    {
        public EnemyType Value;
    }
    
    [Game]
    public sealed class SpawnTimeComponent : IComponent
    {
        public float Value;
    }
    
    [Game]
    public sealed class CurrentSpawnTimeComponent : IComponent
    {
        public float Value;
    }
    
    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class SpawnTimerReadyComponent : IComponent
    {
    }
    
}