using Game.Components;
using Game.Factories;
using Services.Windows;
using TMPro;
using UI;

namespace Infrastructure.StateMachine.Gameplay
{
    public class BootstrapGameplayState : IGameplayState
    {
        private readonly Contexts _contexts;

        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowService _windowService;

        public BootstrapGameplayState(Contexts contexts, IPlayerFactory playerFactory, IEnemyFactory enemyFactory,
            IWindowService windowService)
        {
            _contexts = contexts;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _windowService = windowService;
        }

        public void Enter()
        {
            _windowService.Initialize();
            _playerFactory.Initialize(_contexts.game);
            GameEntity player = _playerFactory.Create();
            _enemyFactory.Initialize(_contexts.game, player.creationIndex);
            CreateSpawners();
            CreateHud(player);
        }

        public void Exit()
        {
        }

        private void CreateHud(GameEntity player)
        {
            PlayerHud hud = _windowService.CreateHud();
            hud.Initialize(_contexts, player);
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
    }
}