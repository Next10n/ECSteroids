using Services;
using UnityEngine;

namespace Game.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IRandomProvider _randomProvider;
        private readonly GameContext _gameContext;
        private readonly ICameraProvider _cameraProvider;

        private int _playerIndex;
        private Bounds _bounds;

        public EnemyFactory(IRandomProvider randomProvider, GameContext gameContext, ICameraProvider cameraProvider)
        {
            _randomProvider = randomProvider;
            _gameContext = gameContext;
            _cameraProvider = cameraProvider;
        }

        public void Initialize(int index)
        {
            _playerIndex = index;
            _bounds = _cameraProvider.GetMainCameraBounds();
        }

        public GameEntity CreateAsteroid()
        {
            GameEntity asteroid = _gameContext.CreateEntity();
            AddSpaceComponents(asteroid);
            asteroid.AddAsset("Asteroid");
            return asteroid;
        }

        public GameEntity CreateUfo()
        {
            GameEntity ufo = _gameContext.CreateEntity();
            AddSpaceComponents(ufo);
            ufo.AddAsset("UFO");
            return ufo;
        }

        private void AddSpaceComponents(GameEntity gameEntity)
        {
            gameEntity.AddPosition(RandomBoundsPosition());
            gameEntity.AddVelocity(new Vector2(_randomProvider.Random(0f, 1f), _randomProvider.Random(0, 1f)));
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