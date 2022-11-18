using Services.AssetProvider;
using Services.View;
using UnityEngine;
using Views.Systems;

public class Main : MonoBehaviour
{
    private Contexts _contexts;
    private SpawnAssetViewSystem _spawnAssetViewSystem;
    private DiContainer _diContainer;
    private RegisterServicesSystem _registerServicesSystem;

    private void Awake()
    {
        _contexts = new Contexts();

        _diContainer = new DiContainer();
        RegisterServices();

        _spawnAssetViewSystem = new SpawnAssetViewSystem(_contexts.view, _contexts);
        _registerServicesSystem = new RegisterServicesSystem(_contexts, _diContainer);
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
    }

    private void RegisterServices()
    {
        _diContainer.Register<IAssetProvider, AssetProvider>(new AssetProvider());
        _diContainer.Register<IViewService, UnityViewService>(new UnityViewService(_diContainer.Resolve<IAssetProvider>()));
    }
}