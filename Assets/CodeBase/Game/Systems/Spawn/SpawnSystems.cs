namespace Game.Systems
{
    public sealed class SpawnSystems : Feature
    {
        public SpawnSystems(Contexts contexts)
        {
            Add(new SpawnTimerSystem(contexts));
            Add(new SpawnEnemySystem(contexts));
        }
    }
}