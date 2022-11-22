using Entitas;

namespace Game.Components
{
    public enum EnemyType
    {
        Asteroid = 0,
        Ufo = 1
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
    
}