using UnityEngine;

namespace Game.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly Contexts _contexts;

        public PlayerFactory(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public GameEntity Create(/* player data */)
        {
            GameEntity player = _contexts.game.CreateEntity();
            player.AddAsset("Player");
            player.AddPosition(new Vector2(0f, 0f));
            player.AddRotationAngle(0f);
            player.AddDeceleration(1f);
            player.AddAccelerationSpeed(5f);
            player.AddAngularSpeed(200f);
            player.isPlayer = true;
            player.isTeleportable = true;
            return player;
        }
    }
}