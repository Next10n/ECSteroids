namespace Game.Systems.WeaponSystems
{
    public sealed class CommonSystems : Feature
    {
        public CommonSystems(Contexts contexts)
        {
            Add(new DestroyDelaySystem(contexts));
            Add(new DestroyTimerSystem(contexts));
        }
    }
}