namespace Game.Systems.WeaponSystems
{
    public sealed class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts contexts)
        {
            Add(new DestroySystem(contexts));
            Add(new ScoreSystems(contexts));
        }
    }
}