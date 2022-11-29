namespace Core.Game.Systems.Weapon
{
    public sealed class WeaponSystems : Feature
    {
        public WeaponSystems(Contexts contexts)
        {
            Add(new SwitchPlayerWeaponSystem(contexts));
            Add(new ShootSystem(contexts));
        }
    }
}