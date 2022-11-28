using Game.Components;
using Services;
using UnityEngine;

namespace Game.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IRandomProvider _randomProvider;
        private readonly ICameraProvider _cameraProvider;

        private GameContext _gameContext;
        private int _playerIndex;
        private Bounds _bounds;

        public EnemyFactory(IRandomProvider randomProvider, ICameraProvider cameraProvider)
        {
            _randomProvider = randomProvider;
            _cameraProvider = cameraProvider;
        }

        public void Initialize(GameContext gameContext, int playerIndex)
        {
            _gameContext = gameContext;
            _playerIndex = playerIndex;
            _bounds = _cameraProvider.GetMainCameraBounds();
        }

        public void Create(EnemyType spawnerValue)
        {
            switch (spawnerValue)
            {
                case EnemyType.Asteroid:
                    CreateAsteroid();
                    break;
                case EnemyType.Ufo:
                    CreateUfo();
                    break;
            }
        }

        private GameEntity CreateAsteroid()
        {
            GameEntity asteroid = _gameContext.CreateEntity();
            AddSpaceComponents(asteroid);
            asteroid.AddAsset("Asteroid");
            return asteroid;
        }

        private GameEntity CreateUfo()
        {
            GameEntity ufo = _gameContext.CreateEntity();
            AddSpaceComponents(ufo);
            ufo.AddAsset("UFO");
            return ufo;
        }

        private void AddSpaceComponents(GameEntity gameEntity)
        {
            gameEntity.AddPosition(RandomBoundsPosition());
            gameEntity.AddVelocity(new Vector2(_randomProvider.Random(1f, 3f), _randomProvider.Random(1, 3f)));
            gameEntity.isTeleportable = true;
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