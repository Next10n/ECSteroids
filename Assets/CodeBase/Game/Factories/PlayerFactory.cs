using UnityEngine;

namespace Game.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private GameContext _gameContext;
        
        public void Initialize(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public GameEntity Create(/* player data */)
        {
            GameEntity player = _gameContext.CreateEntity();
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