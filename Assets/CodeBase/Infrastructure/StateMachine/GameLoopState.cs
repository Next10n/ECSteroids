using Game.Factories;
using Game.Systems;
using Services;
using Services.Input;
using Services.Systems;
using Services.Time;
using Services.View;

namespace Infrastructure.StateMachine
{
    public class GameLoopState : IState, ILateUpdatable, IUpdatable
    {
        private readonly IPlayerFactory _playerFactory;

        private readonly RegisterServicesSystem _registerServicesSystem;
        private readonly SpawnAssetViewSystem _spawnAssetViewSystem;
        private readonly GameEventSystems _gameEventSystems;
        private readonly MovementSystems _movementSystems;
        private readonly DestroyPlayerOnTrigger2DSystem _destroyPlayerOnTrigger2DSystem;
        private readonly GameCleanupSystems _gameCleanupSystems;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IUpdateService _updateService;


        public GameLoopState(IPlayerFactory playerFactory, Contexts contexts, IViewService viewService,
            ITimeService timeService, IInputService inputService, ICameraProvider cameraProvider,
            IEnemyFactory enemyFactory, IUpdateService updateService)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
            _updateService = updateService;
            _spawnAssetViewSystem = new SpawnAssetViewSystem(contexts.game, contexts);
            _registerServicesSystem = new RegisterServicesSystem(contexts, viewService, timeService, inputService,
                cameraProvider);
            _gameEventSystems = new GameEventSystems(contexts);
            _movementSystems = new MovementSystems(contexts);
            _gameCleanupSystems = new GameCleanupSystems(contexts);
            _destroyPlayerOnTrigger2DSystem = new DestroyPlayerOnTrigger2DSystem(contexts);
        }

        public void Enter()
        {
            _registerServicesSystem.Initialize();
            _spawnAssetViewSystem.Initialize();
            _movementSystems.Initialize();
            _playerFactory.Create(); // TODO to GameLoopStateMachine
            _updateService.RegisterUpdatable(this);
            _updateService.RegisterLateUpdatable(this);
        }

        public void Update()
        {
            _movementSystems.Execute();
            _destroyPlayerOnTrigger2DSystem.Execute();
        }

        public void LateUpdate()
        {
            _spawnAssetViewSystem.Execute();
            _gameEventSystems.Execute();
            _gameCleanupSystems.Cleanup();
        }

        public void Exit()
        {
        }
    }
}