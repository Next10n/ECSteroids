using Core.Factories;
using Core.Game.Systems;
using Core.Game.Systems.DestroySystems;
using Core.Game.Systems.ScoreSystems;
using Core.Game.Systems.Spawn;
using Core.Game.Systems.ViewSystems;
using Core.Meta.Systems;
using Infrastructure.Services.Input;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Time;
using Infrastructure.Services.View;
using Infrastructure.Services.Windows;

namespace Infrastructure.Services.Ecs
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
        private WeaponSystems _weaponSystems;
        private GameplaySystems _gameplaySystems;

        private readonly IViewService _viewService;
        private readonly ITimeService _timeService;
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowService _windowService;
        private readonly IBulletFactory _bulletFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IRandomProvider _randomProvider;

        public EcsService(IViewService viewService, ITimeService timeService, IInputService inputService,
            ICameraProvider cameraProvider, IEnemyFactory enemyFactory, IWindowService windowService, IBulletFactory bulletFactory,
            IStaticDataService staticDataService, IRandomProvider randomProvider)
        {
            _viewService = viewService;
            _timeService = timeService;
            _inputService = inputService;
            _cameraProvider = cameraProvider;
            _enemyFactory = enemyFactory;
            _windowService = windowService;
            _bulletFactory = bulletFactory;
            _staticDataService = staticDataService;
            _randomProvider = randomProvider;
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
            _gameplaySystems.Execute();
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
            _gameplaySystems.Initialize();
        }

        private Contexts CreateContexts() =>
            _contexts = new Contexts();

        private void CreateSystems()
        {
            _spawnSystem = new SpawnSystems(_contexts);
            _createAssetViewSystem = new CreateAssetViewSystem(_contexts.game, _contexts);
            _registerServicesSystem = new RegisterServicesSystem(_contexts, _viewService, _timeService, _inputService,
                _cameraProvider, _enemyFactory, _windowService, _bulletFactory, _staticDataService, _randomProvider);
            _gameEventSystems = new GameEventSystems(_contexts);
            _movementSystems = new MovementSystems(_contexts);
            _gameCleanupSystems = new GameCleanupSystems(_contexts);
            _destroyPlayerOnTriggerEnemySystem = new DestroyPlayerOnTriggerEnemySystem(_contexts);
            _showResultSystem = new ShowResultSystem(_contexts);
            _weaponSystems = new WeaponSystems(_contexts);
            _gameplaySystems = new GameplaySystems(_contexts);
        }
    }
}