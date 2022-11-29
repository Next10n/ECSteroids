namespace Game.Systems
{
    public sealed class MovementSystems : Feature
    {
        public MovementSystems(Contexts contexts)
        {
            Add(new AddRotationVelocitySystem(contexts));
            Add(new CalculateDirectionSystem(contexts));
            Add(new AddPlayerVelocitySystem(contexts));
            Add(new DecelerationSystem(contexts));
            Add(new MoveVelocitySystem(contexts));
            Add(new TeleportSystem(contexts));
        }
    }
}