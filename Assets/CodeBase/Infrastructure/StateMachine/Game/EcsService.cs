using Game.Factories;
using Game.Systems;
using Game.Systems.Dead;
using Game.Systems.WeaponSystems;
using Services;
using Services.Input;
using Services.Systems;
using Services.Time;
using Services.View;
using Services.Windows;

namespace Infrastructure.StateMachine.Game
{
    public class EcsService : IEcsService
    {
        private RegisterServicesSystem _registerServicesSystem;
        private CreateAssetViewSystem _createAssetViewSystem;
        private GameEventSystems _gameEventSystems;
        private MovementSystems _movementSystems;
        private DestroyPlayerOnTriggerEnemySystem _destroyPlayerOnTriggerEnemySystem;
        private GameCleanupSystems _gameCleanupSystems;
        private SpawnSystems _spawnSystem;
        private Contexts _contexts;
        private ShowResultSystem _showResultSystem;
        private DestroyDeadSystem _destroyDeadSystem;

        private readonly IViewService _viewService;
        private readonly ITimeService _timeService;
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowService _windowService;
        private readonly IBulletFactory _bulletFactory;
        private WeaponSystems _weaponSystems;
        private CommonSystems _commonSystems;

        public EcsService(IViewService viewService, ITimeService timeService, IInputService inputService,
            ICameraProvider cameraProvider, IEnemyFactory enemyFactory, IWindowService windowService, IBulletFactory bulletFactory)
        {
            _viewService = viewService;
            _timeService = timeService;
            _inputService = inputService;
            _cameraProvider = cameraProvider;
            _enemyFactory = enemyFactory;
            _windowService = windowService;
            _bulletFactory = bulletFactory;
        }

        public Contexts CreateEcsWorld()
        {
            Contexts contexts = CreateContexts();
            CreateSystems();
            InitializeSystems();
            return contexts;
        }

        public void Update()
        {
            _movementSystems.Execute();
            _spawnSystem.Execute();
            _weaponSystems.Execute();
            _destroyPlayerOnTriggerEnemySystem.Execute();
            _destroyDeadSystem.Execute();
            _commonSystems.Execute();
        }

        public void LateUpdate()
        {
            _createAssetViewSystem.Execute();
            _showResultSystem.Execute();
            _gameEventSystems.Execute();
            _gameCleanupSystems.Cleanup();
        }

        private void InitializeSystems()
        {
            _registerServicesSystem.Initialize();
            _createAssetViewSystem.Initialize();
            _movementSystems.Initialize();
            _spawnSystem.Initialize();
            _showResultSystem.Initialize();
            _weaponSystems.Initialize();
            _commonSystems.Initialize();
        }

        private Contexts CreateContexts() =>
            _contexts = new Contexts();

        private void CreateSystems()
        {
            _spawnSystem = new SpawnSystems(_contexts);
            _createAssetViewSystem = new CreateAssetViewSystem(_contexts.game, _contexts);
            _registerServicesSystem = new RegisterServicesSystem(_contexts, _viewService, _timeService, _inputService,
                _cameraProvider, _enemyFactory, _windowService, _bulletFactory);
            _gameEventSystems = new GameEventSystems(_contexts);
            _movementSystems = new MovementSystems(_contexts);
            _gameCleanupSystems = new GameCleanupSystems(_contexts);
            _destroyPlayerOnTriggerEnemySystem = new DestroyPlayerOnTriggerEnemySystem(_contexts);
            _showResultSystem = new ShowResultSystem(_contexts);
            _destroyDeadSystem = new DestroyDeadSystem(_contexts);
            _weaponSystems = new WeaponSystems(_contexts);
            _commonSystems = new CommonSystems(_contexts);
        }
    }
}