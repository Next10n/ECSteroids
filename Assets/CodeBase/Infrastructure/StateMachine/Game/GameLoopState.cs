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
        private SpawnAssetViewSystem _spawnAssetViewSystem;
        private GameEventSystems _gameEventSystems;
        private MovementSystems _movementSystems;
        private DestroyPlayerOnTrigger2DSystem _destroyPlayerOnTrigger2DSystem;
        private GameCleanupSystems _gameCleanupSystems;
        private Contexts _contexts;
        
        private readonly IUpdateService _updateService;
        private readonly IViewService _viewService;
        private readonly ITimeService _timeService;
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;

        public GameLoopState(IViewService viewService, ITimeService timeService, IInputService inputService, 
            ICameraProvider cameraProvider, IUpdateService updateService)
        {
            _viewService = viewService;
            _timeService = timeService;
            _inputService = inputService;
            _cameraProvider = cameraProvider;
            _updateService = updateService;
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
            _spawnAssetViewSystem.Initialize();
            _movementSystems.Initialize();            
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
            _updateService.UnRegisterUpdatable(this);
            _updateService.UnRegisterLateUpdatable(this);
        }

        private void CreateContexts() => 
            _contexts = new Contexts();

        private void CreateSystems()
        {
            _spawnAssetViewSystem = new SpawnAssetViewSystem(_contexts.game, _contexts);
            _registerServicesSystem = new RegisterServicesSystem(_contexts, _viewService, _timeService, _inputService,
                _cameraProvider);
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
            GameplayStateMachine gameplayStateMachine = new GameplayStateMachine(_contexts);
            gameplayStateMachine.Enter<BootstrapGameplayState>();
        }
    }
}