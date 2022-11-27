using Game.Components;
using Game.Factories;
using Services.SceneProvider;
using Services.UpdateService;
using Services.Windows;
using UI;

namespace Infrastructure.StateMachine.Game
{
    public class LoadGameState : IState
    {
        private const string GameScene = "Game";
        private readonly ISceneProvider _sceneProvider;
        private readonly IStateMachine _stateMachine;
        private readonly IEcsService _ecsService;
        private readonly IUpdateService _updateService;
        private readonly IWindowService _windowService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;

        public LoadGameState(ISceneProvider sceneProvider, IStateMachine stateMachine, IEcsService ecsService, IUpdateService updateService,
            IWindowService windowService, IPlayerFactory playerFactory, IEnemyFactory enemyFactory)
        {
            _sceneProvider = sceneProvider;
            _stateMachine = stateMachine;
            _ecsService = ecsService;
            _updateService = updateService;
            _windowService = windowService;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }

        public void Enter()
        {
            _sceneProvider.Load(GameScene, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            Contexts contexts = _ecsService.CreateEcsWorld();
            _updateService.RegisterUpdatable(_ecsService);
            _updateService.RegisterLateUpdatable(_ecsService);
            _windowService.Initialize();
            _playerFactory.Initialize(contexts.game);
            GameEntity player = _playerFactory.Create();
            _enemyFactory.Initialize(contexts.game, player.creationIndex);
            CreateSpawners(contexts);
            CreateHud(contexts, player);
        }

        private void CreateHud(Contexts contexts, GameEntity player)
        {
            PlayerHud hud = _windowService.CreateHud();
            hud.Initialize(contexts, player);
        }

        private void CreateSpawners(Contexts contexts)
        {
            GameEntity asteroidSpawner = contexts.game.CreateEntity();
            asteroidSpawner.AddSpawner(EnemyType.Asteroid);
            asteroidSpawner.AddSpawnTime(5f);
            asteroidSpawner.AddCurrentSpawnTime(0f);

            GameEntity ufoSpawner = contexts.game.CreateEntity();
            ufoSpawner.AddSpawner(EnemyType.Ufo);
            ufoSpawner.AddSpawnTime(10f);
            ufoSpawner.AddCurrentSpawnTime(0f);
        }
    }
}