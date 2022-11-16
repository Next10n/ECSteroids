namespace Core.Systems
{
    public sealed class DamageSystems : Feature
    {
        public DamageSystems(Contexts contexts)
        {
            // Add(new ApplyDamageSystem(contexts));
            Add(new ApplyDamageReactiveSystem(contexts));
        }
    }
}