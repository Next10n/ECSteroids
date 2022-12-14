namespace Core.Game.Systems
{
    public sealed class MovementSystems : Feature
    {
        public MovementSystems(Contexts contexts)
        {
            Add(new AddPlayerRotationSystem(contexts));
            Add(new CalculateDirectionSystem(contexts));
            Add(new AddPlayerVelocitySystem(contexts));
            Add(new DecelerationSystem(contexts));
            Add(new FollowPositionSystem(contexts));
            Add(new MoveVelocitySystem(contexts));
            Add(new TeleportSystem(contexts));
        }
    }
}