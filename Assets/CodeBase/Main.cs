using Services.AssetProvider;
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

    private void Awake()
    {
        _contexts = new Contexts();

        _diContainer = new DiContainer();
        RegisterServices();

        _spawnAssetViewSystem = new SpawnAssetViewSystem(_contexts.game, _contexts);
        _registerServicesSystem = new RegisterServicesSystem(_contexts, _diContainer);
        _gameEventSystems = new GameEventSystems(_contexts);
        
        CreatePlayer();
    }


    private void Start()
    {
        _registerServicesSystem.Initialize();
        _spawnAssetViewSystem.Initialize();
    }

    private void Update()
    {
        _spawnAssetViewSystem.Execute();
    }

    private void LateUpdate()
    {
        _gameEventSystems.Execute();
    }

    private void CreatePlayer()
    {
        GameEntity player = _contexts.game.CreateEntity();
        player.AddAsset("Player");
        player.AddPosition(new Vector2(0f, 0f));
    }

    private void RegisterServices()
    {
        _diContainer.Register<IAssetProvider, AssetProvider>(new AssetProvider());
        _diContainer.Register<IViewService, UnityViewService>(new UnityViewService(_diContainer.Resolve<IAssetProvider>()));
    }
}