using Core.Factories;
using Extensions;
using Infrastructure.Services.SceneProvider;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Windows;
using StaticData;

namespace Infrastructure.Services.StateMachine.States
{
    public class LoadGameState : IPayloadState<Contexts>
    {
        private readonly ISceneProvider _sceneProvider;
        private readonly IWindowService _windowService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowFactory _windowFactory;
        private readonly IStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private Contexts _contexts;

        public LoadGameState(ISceneProvider sceneProvider, IWindowService windowService, IPlayerFactory playerFactory,
            IEnemyFactory enemyFactory, IWindowFactory windowFactory, IStateMachine stateMachine, IStaticDataService staticDataService)
        {
            _sceneProvider = sceneProvider;
            _windowService = windowService;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _windowFactory = windowFactory;
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter(Contexts contexts)
        {
            _contexts = contexts;
            _sceneProvider.Load(Constants.GameScene, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _windowFactory.Initialize(_stateMachine, _contexts);
            GameEntity player = _playerFactory.Create(_staticDataService.PlayerStaticData);
            _enemyFactory.Initialize(_contexts.game, player.creationIndex);
            _contexts.game.ReplaceScore(0);
            CreateSpawners(_contexts);
            CreateHud(_contexts, player);
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