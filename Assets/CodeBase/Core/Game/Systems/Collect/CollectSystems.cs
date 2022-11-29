namespace Core.Game.Systems.Collect
{
    public sealed class CollectSystems : Feature
    {
        public CollectSystems(Contexts contexts)
        {
            Add(new CollectDestroyTimerSystem(contexts));
            Add(new CollectSpawnerTimerSystem(contexts));
        }
    }
}