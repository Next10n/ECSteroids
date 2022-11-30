namespace Core.Game.Systems.Weapon
{
    public sealed class WeaponSystems : Feature
    {
        public WeaponSystems(Contexts contexts)
        {
            Add(new RestoreLaserTimerSystem(contexts));
            Add(new CreateRestoreLaserRequestSystem(contexts));
            Add(new LaserRestoreSystem(contexts));
            Add(new SwitchPlayerWeaponSystem(contexts));
            Add(new SwitchWeaponSystem(contexts));
            Add(new CreateShootRequestSystem(contexts));
            Add(new ValidateShootLaserRequestSystem(contexts));
            Add(new ShootBulletWeaponSystem(contexts));
            Add(new ShootLaserWeaponSystem(contexts));
            Add(new ConsumeLaserStorageSystem(contexts));
            Add(new CreateRestoreTimerSystem(contexts));
        }
    }
}