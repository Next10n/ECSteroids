namespace Core.Game.Systems.Score
{
    public sealed class WeaponSystems : Feature
    {
        public WeaponSystems(Contexts contexts)
        {
            Add(new ShootSystem(contexts));
        }
    }
}