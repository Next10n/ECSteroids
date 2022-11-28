using Game.Components;
using Game.Factories;
using Game.Systems.WeaponSystems;
using Infrastructure.StateMachine.Gameplay;
using Services.SceneProvider;
using Services.StaticData;
using Services.UpdateService;
using Services.Windows;
using StaticData;

namespace Infrastructure.StateMachine.Game
{
    public class LoadGameState : IState
    {
        private const string GameScene = "Game";
        private readonly ISceneProvider _sceneProvider;
        private readonly IEcsService _ecsService;
        private readonly IUpdateService _updateService;
        private readonly IWindowService _windowService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowFactory _windowFactory;
        private readonly IStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly IBulletFactory _bulletFactory;

        public LoadGameState(ISceneProvider sceneProvider, IEcsService ecsService, IUpdateService updateService,
            IWindowService windowService, IPlayerFactory playerFactory, IEnemyFactory enemyFactory, IWindowFactory windowFactory,
            IStateMachine stateMachine, IStaticDataService staticDataService, IBulletFactory bulletFactory)
        {
            _sceneProvider = sceneProvider;
            _ecsService = ecsService;
            _updateService = updateService;
            _windowService = windowService;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _windowFactory = windowFactory;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _bulletFactory = bulletFactory;
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
            _bulletFactory.Initialize(contexts);
            _windowFactory.Initialize(_stateMachine, contexts);
            _playerFactory.Initialize(contexts.game);
            GameEntity player = _playerFactory.Create(_staticDataService.PlayerStaticData);
            _enemyFactory.Initialize(contexts.game, player.creationIndex);
            CreateSpawners(contexts);
            CreateHud(contexts, player);
        }

        private void CreateHud(Contexts contexts, GameEntity player)
        {
            _windowService.ShowHud();
            _windowService.InitializeHud(contexts, player);
        }

        private void CreateSpawners(Contexts contexts)
        {
            foreach(SpawnerStaticData spawnerStaticData in _staticDataService.SpawnersStaticData) 
                CreateSpawner(contexts, spawnerStaticData);
        }

        private void CreateSpawner(Contexts contexts, SpawnerStaticData spawnerStaticData)
        {
            GameEntity spawner = contexts.game.CreateEntity();
            spawner.AddSpawner(spawnerStaticData.EnemyType);
            spawner.AddSpawnTime(spawnerStaticData.SpawnDelay);
            spawner.AddCurrentSpawnTime(0f);
        }
    }
}