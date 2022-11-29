namespace Game.Systems.WeaponSystems
{
    public sealed class DestroySystem : Feature
    {
        public DestroySystem(Contexts contexts)
        {
            Add(new DestroyDelaySystem(contexts));
            Add(new DestroyTimerSystem(contexts));
            Add(new DestructAsteroidSystem(contexts));
            Add(new DestroyEnemySystem(contexts));
        }
    }
}