namespace Core.Game.Systems.Spawn
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