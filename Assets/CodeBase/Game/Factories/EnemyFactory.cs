using Game.Components;
using Infrastructure.StateMachine.Gameplay;
using Services;
using Services.StaticData;
using StaticData;
using UnityEngine;

namespace Game.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IRandomProvider _randomProvider;
        private readonly ICameraProvider _cameraProvider;
        private readonly IStaticDataService _staticDataService;

        private GameContext _gameContext;
        private int _playerIndex;
        private Bounds _bounds;

        public EnemyFactory(IRandomProvider randomProvider, ICameraProvider cameraProvider, IStaticDataService staticDataService)
        {
            _randomProvider = randomProvider;
            _cameraProvider = cameraProvider;
            _staticDataService = staticDataService;
        }

        public void Initialize(GameContext gameContext, int playerIndex)
        {
            _gameContext = gameContext;
            _playerIndex = playerIndex;
            _bounds = _cameraProvider.GetMainCameraBounds();
        }

        public void Create(EnemyType enemyType)
        {
            EnemyStaticData enemyStaticData = _staticDataService.GetEnemyData(enemyType);
            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    CreateAsteroid(enemyStaticData);
                    break;
                case EnemyType.Ufo:
                    CreateUfo(enemyStaticData);
                    break;
            }
        }

        private GameEntity CreateAsteroid(EnemyStaticData enemyStaticData)
        {
            return CreateEnemy(enemyStaticData);
        }

        private GameEntity CreateUfo(EnemyStaticData enemyStaticData)
        {
            return CreateEnemy(enemyStaticData);
        }

        private GameEntity CreateEnemy(EnemyStaticData enemyStaticData)
        {
            GameEntity enemy = _gameContext.CreateEntity();
            AddSpaceComponents(enemy, enemyStaticData);
            enemy.AddAsset(enemyStaticData.AssetPath);
            enemy.isEnemy = true;
            return enemy;
        }

        private void AddSpaceComponents(GameEntity gameEntity, EnemyStaticData enemyStaticData)
        {
            gameEntity.AddPosition(RandomBoundsPosition());
            gameEntity.AddVelocity(RandomVelocity(enemyStaticData));
            gameEntity.isTeleportable = true;
        }

        private Vector2 RandomVelocity(EnemyStaticData enemyStaticData)
        {
            float randomX = _randomProvider.Random(0f, 1f) * (_randomProvider.RandomFlag() ? 1f : -1f);
            float randomY = _randomProvider.Random(0f, 1f) * (_randomProvider.RandomFlag() ? 1f : -1f);
            Vector2 randomDirection = new Vector2(randomX, randomY);
            Vector2 velocity = randomDirection.normalized * _randomProvider.Random(enemyStaticData.MaxVelocity, enemyStaticData.MinVelocity);
            return velocity;
        }

        private Vector2 RandomBoundsPosition()
        {
            if (_randomProvider.RandomFlag())
            {
                float x = _randomProvider.Random(-_bounds.extents.x, _bounds.extents.x);
                float y = _bounds.extents.y;
                return new Vector2(x, y);
            }
            else
            {
                float x = _bounds.extents.x;
                float y = _randomProvider.Random(-_bounds.extents.y, _bounds.extents.y);
                return new Vector2(x, y);
            }
        }
    }
}