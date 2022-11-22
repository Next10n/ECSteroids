using Game.Factories;
using Game.Systems;
using Services;
using Services.AssetProvider;
using Services.Input;
using Services.Systems;
using Services.Time;
using Services.View;
using UnityEngine;
using Views.Systems;

public class Main : MonoBehaviour
{
    private Contexts _contexts;
    private DiContainer _diContainer;

    private RegisterServicesSystem _registerServicesSystem;
    private SpawnAssetViewSystem _spawnAssetViewSystem;
    private GameEventSystems _gameEventSystems;
    private MovementSystems _movementSystems;
    private IEnemyFactory _enemyFactory;
    private DestroyPlayerOnTrigger2DSystem _destroyPlayerOnTrigger2DSystem;
    private GameCleanupSystems _gameCleanupSystems;

    private void Awake()
    {
        _contexts = new Contexts();
        _diContainer = DiContainer.Instance;
        RegisterServices();

        _spawnAssetViewSystem = new SpawnAssetViewSystem(_contexts.game, _contexts);
        // _registerServicesSystem = new RegisterServicesSystem(_contexts, _diContainer);
        _gameEventSystems = new GameEventSystems(_contexts);
        _movementSystems = new MovementSystems(_contexts);
        _gameCleanupSystems = new GameCleanupSystems(_contexts);
        _destroyPlayerOnTrigger2DSystem = new DestroyPlayerOnTrigger2DSystem(_contexts);
    }


    private void Start()
    {
        _registerServicesSystem.Initialize();
        _spawnAssetViewSystem.Initialize();
        _movementSystems.Initialize();
        // GameEntity player = CreatePlayer();
        _enemyFactory = _diContainer.Resolve<IEnemyFactory>();
        // _enemyFactory.Initialize(player.creationIndex);

        InvokeRepeating(nameof(CreateAsteroid), 1f, 5f);
        InvokeRepeating(nameof(CreateUfo), 1f, 5f);
    }

    private void Update()
    {
        _movementSystems.Execute();
        _spawnAssetViewSystem.Execute();
        _destroyPlayerOnTrigger2DSystem.Execute();
    }

    private void LateUpdate()
    {
        _gameEventSystems.Execute();
        _gameCleanupSystems.Cleanup();
    }
    
    private void CreateAsteroid()
    {
        _enemyFactory.CreateAsteroid();
    }
    
    private void CreateUfo()
    {
        _enemyFactory.CreateUfo();
    }

    private void RegisterServices()
    {
        _diContainer.Register<IAssetProvider, AssetProvider>(new AssetProvider());
        _diContainer.Register<IViewService, UnityViewService>(
            new UnityViewService(_diContainer.Resolve<IAssetProvider>()));
        _diContainer.Register<ITimeService, UnityTimeService>(new UnityTimeService());
        _diContainer.Register<IInputService, UnityInputService>(new UnityInputService());
        _diContainer.Register<ICameraProvider, UnityCameraProvider>(new UnityCameraProvider());
        _diContainer.Register<IRandomProvider, UnityRandomProvider>(new UnityRandomProvider());
        _diContainer.Register<IEnemyFactory, EnemyFactory>(new EnemyFactory(_diContainer.Resolve<IRandomProvider>()
            , _diContainer.Resolve<ICameraProvider>()));
    }
}