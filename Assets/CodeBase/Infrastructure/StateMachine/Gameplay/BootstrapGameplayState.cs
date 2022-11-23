using Game.Components;
using Game.Factories;

namespace Infrastructure.StateMachine.Gameplay
{
    public class BootstrapGameplayState : IGameplayState
    {
        private readonly Contexts _contexts;
        
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;

        public BootstrapGameplayState(Contexts contexts, IPlayerFactory playerFactory, IEnemyFactory enemyFactory)
        {
            _contexts = contexts;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }
        
        public void Enter()
        {
            _playerFactory.Initialize(_contexts.game);
            GameEntity player = _playerFactory.Create();
            _enemyFactory.Initialize(_contexts.game, player.creationIndex);
            CreateSpawners();
            // TODO Create Hud
        }

        private void CreateSpawners()
        {
            GameEntity asteroidSpawner = _contexts.game.CreateEntity();
            asteroidSpawner.AddSpawner(EnemyType.Asteroid);
            asteroidSpawner.AddSpawnTime(5f);
            asteroidSpawner.AddCurrentSpawnTime(0f);
            
            GameEntity ufoSpawner = _contexts.game.CreateEntity();
            ufoSpawner.AddSpawner(EnemyType.Ufo);
            ufoSpawner.AddSpawnTime(10f);
            ufoSpawner.AddCurrentSpawnTime(0f);
        }

        public void Exit()
        {
            
        }
    }
}