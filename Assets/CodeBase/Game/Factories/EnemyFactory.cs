using System;
using Game.Components;
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

        public GameEntity Create(EnemyType enemyType)
        {
            EnemyStaticData enemyStaticData = _staticDataService.GetEnemyData(enemyType);
            switch(enemyType)
            {
                case EnemyType.Asteroid:
                    return CreateAsteroid(enemyStaticData);
                case EnemyType.Ufo:
                    return CreateUfo(enemyStaticData);
                case EnemyType.AsteroidFragments:
                    return CreateAsteroidFragment(enemyStaticData);
            }

            throw new InvalidOperationException($"Unknown enemy Type {enemyType}");
        }

        private GameEntity CreateAsteroidFragment(EnemyStaticData enemyStaticData)
        {
            return CreateEnemy(enemyStaticData);
        }

        private GameEntity CreateAsteroid(EnemyStaticData enemyStaticData)
        {
            GameEntity asteroid = CreateEnemy(enemyStaticData);
            asteroid.isDestructible = true;
            asteroid.AddPosition(RandomBoundsPosition());
            return asteroid;
        }

        private GameEntity CreateUfo(EnemyStaticData enemyStaticData)
        {
            GameEntity ufo = CreateEnemy(enemyStaticData);
            ufo.AddPosition(RandomBoundsPosition());
            return ufo;
        }

        private GameEntity CreateEnemy(EnemyStaticData enemyStaticData)
        {
            GameEntity enemy = _gameContext.CreateEntity();
            enemy.AddAsset(enemyStaticData.AssetPath);
            enemy.isEnemy = true;
            enemy.AddAddScore(enemyStaticData.Score);
            enemy.AddVelocity(RandomVelocity(enemyStaticData));
            enemy.isTeleportable = true;
            return enemy;
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
            if(_randomProvider.RandomFlag())
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