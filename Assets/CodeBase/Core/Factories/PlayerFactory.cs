using Core.Game.Components;
using StaticData;
using UnityEngine;

namespace Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private GameContext _gameContext;
        
        public void Initialize(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public GameEntity Create(PlayerStaticData playerStaticData)
        {
            GameEntity player = _gameContext.CreateEntity();
            player.AddAsset(playerStaticData.PlayerAssetPath);
            player.AddPosition(new Vector2(0f, 0f));
            player.AddRotationAngle(0f);
            player.AddDeceleration(playerStaticData.Deceleration);
            player.AddAccelerationSpeed(playerStaticData.AccelerationSpeed);
            player.AddAngularSpeed(playerStaticData.AngularSpeed);
            player.AddVelocity(Vector2.zero);
            player.isPlayer = true;
            player.isTeleportable = true;
            player.isBulletWeapon = true;
            player.AddLaserStorage(playerStaticData.MaxLasers);
            player.AddMaxLasersWeapon(playerStaticData.MaxLasers);
            player.AddLaserRestoreTime(playerStaticData.LaserRestoreTime);
            player.AddDestroyAssetView(playerStaticData.DestroyAsset);
            return player;
        }
    }
}