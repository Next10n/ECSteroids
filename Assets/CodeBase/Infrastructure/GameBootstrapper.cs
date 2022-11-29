using Core.Factories;
using Infrastructure.Services;
using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.Coroutine;
using Infrastructure.Services.Ecs;
using Infrastructure.Services.Input;
using Infrastructure.Services.SceneProvider;
using Infrastructure.Services.StateMachine;
using Infrastructure.Services.StateMachine.States;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Time;
using Infrastructure.Services.UpdateService;
using Infrastructure.Services.View;
using Infrastructure.Services.Windows;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private UnityUpdateService _updateService;
        [SerializeField] private CoroutineRunner _coroutineRunner;

        private IAssetProvider _assetProvider;
        private IViewService _viewService;
        private ITimeService _timeService;
        private IInputService _inputService;
        private ICameraProvider _cameraProvider;
        private IRandomProvider _randomProvider;
        private ISceneProvider _sceneProvider;
        private IStateMachine _gameStateMachine;
        private IWindowService _windowService;
        private IPlayerFactory _playerFactory;
        private IEnemyFactory _enemyFactory;
        private IEcsService _ecsService;
        private IWindowFactory _windowFactory;
        private IStaticDataService _staticDataService;
        private IBulletFactory _bulletFactory;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            CreateServices();
        }

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }

        private void CreateServices()
        {
            _assetProvider = new AssetProvider();
            _viewService = new UnityViewService(_assetProvider);
            _timeService = new UnityTimeService();
            _inputService = new UnityInputService();
            _cameraProvider = new UnityCameraProvider();
            _randomProvider = new UnityRandomProvider();
            _sceneProvider = new UnitySceneProvider(_coroutineRunner);
            _windowFactory = new WindowFactory(_assetProvider);
            _windowService = new WindowService(_windowFactory);
            _playerFactory = new PlayerFactory();
            _staticDataService = new StaticDataService(_assetProvider);
            _enemyFactory = new EnemyFactory(_randomProvider, _cameraProvider, _staticDataService);
            _bulletFactory = new BulletFactory(_staticDataService);
            _ecsService = new EcsService(_viewService, _timeService, _inputService, _cameraProvider, _enemyFactory, _windowService,
                _bulletFactory, _staticDataService, _randomProvider);
            _gameStateMachine = new GameStateMachine(_updateService, _windowService, _sceneProvider, _ecsService, _playerFactory, _enemyFactory,
                _windowFactory, _staticDataService, _bulletFactory);
        }
    }
}