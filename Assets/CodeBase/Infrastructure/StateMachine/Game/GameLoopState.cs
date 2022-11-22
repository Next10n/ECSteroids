using Game.Factories;
using Game.Systems;
using Infrastructure.StateMachine.Gameplay;
using Services;
using Services.Input;
using Services.Systems;
using Services.Time;
using Services.UpdateService;
using Services.View;

namespace Infrastructure.StateMachine.Game
{
    public class GameLoopState : IGameState, ILateUpdatable, IUpdatable
    {
        private RegisterServicesSystem _registerServicesSystem;
        private CreateAssetViewSystem _createAssetViewSystem;
        private GameEventSystems _gameEventSystems;
        private MovementSystems _movementSystems;
        private DestroyPlayerOnTrigger2DSystem _destroyPlayerOnTrigger2DSystem;
        private GameCleanupSystems _gameCleanupSystems;
        private SpawnSystems _spawnSystem;
        private Contexts _contexts;

        private readonly IUpdateService _updateService;
        private readonly IViewService _viewService;
        private readonly ITimeService _timeService;
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IPlayerFactory _playerFactory;

        public GameLoopState(IViewService viewService, ITimeService timeService, IInputService inputService,
            ICameraProvider cameraProvider, IUpdateService updateService, IEnemyFactory enemyFactory,
            IPlayerFactory playerFactory)
        {
            _viewService = viewService;
            _timeService = timeService;
            _inputService = inputService;
            _cameraProvider = cameraProvider;
            _updateService = updateService;
            _enemyFactory = enemyFactory;
            _playerFactory = playerFactory;
        }

        public void Enter()
        {
            CreateContexts();
            CreateSystems();
            InitializeSystems();
            RegisterUpdatable();
            StartGameplay();
        }

        private void InitializeSystems()
        {
            _registerServicesSystem.Initialize();
            _createAssetViewSystem.Initialize();
            _movementSystems.Initialize();
            _spawnSystem.Initialize();
        }

        public void Update()
        {
            _movementSystems.Execute();
            _spawnSystem.Execute();
            _destroyPlayerOnTrigger2DSystem.Execute();
        }

        public void LateUpdate()
        {
            _createAssetViewSystem.Execute();
            _gameEventSystems.Execute();
            _gameCleanupSystems.Cleanup();
        }

        public void Exit()
        {
            _updateService.UnRegisterUpdatable(this);
            _updateService.UnRegisterLateUpdatable(this);
        }

        private void CreateContexts() =>
            _contexts = new Contexts();

        private void CreateSystems()
        {
            _spawnSystem = new SpawnSystems(_contexts);
            _createAssetViewSystem = new CreateAssetViewSystem(_contexts.game, _contexts);
            _registerServicesSystem = new RegisterServicesSystem(_contexts, _viewService, _timeService, _inputService,
                _cameraProvider, _enemyFactory);
            _gameEventSystems = new GameEventSystems(_contexts);
            _movementSystems = new MovementSystems(_contexts);
            _gameCleanupSystems = new GameCleanupSystems(_contexts);
            _destroyPlayerOnTrigger2DSystem = new DestroyPlayerOnTrigger2DSystem(_contexts);
        }

        private void RegisterUpdatable()
        {
            _updateService.RegisterUpdatable(this);
            _updateService.RegisterLateUpdatable(this);
        }

        private void StartGameplay()
        {
            GameplayStateMachine gameplayStateMachine =
                new GameplayStateMachine(_contexts, _playerFactory, _enemyFactory);
            gameplayStateMachine.Enter<BootstrapGameplayState>();
        }
    }
}