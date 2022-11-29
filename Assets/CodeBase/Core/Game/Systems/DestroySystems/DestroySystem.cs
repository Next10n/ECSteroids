namespace Core.Game.Systems.DestroySystems
{
    public sealed class DestroySystem : Feature
    {
        public DestroySystem(Contexts contexts)
        {
            Add(new DestroyDelaySystem(contexts));
            Add(new DestructAsteroidSystem(contexts));
            Add(new DestroyEnemySystem(contexts));
            Add(new DestroyBulletSystem(contexts));
            Add(new DestroyPlayerOnTriggerEnemySystem(contexts));
        }
    }
}