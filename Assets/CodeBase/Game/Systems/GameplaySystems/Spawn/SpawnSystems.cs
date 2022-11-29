using Game.Systems.Spawn;

namespace Game.Systems
{
    public sealed class SpawnSystems : Feature
    {
        public SpawnSystems(Contexts contexts)
        {
            Add(new AddSpawnerTimerSystem(contexts));
            Add(new CompleteSpawnTimerSystem(contexts));
            Add(new SpawnEnemySystem(contexts));
        }
    }
}