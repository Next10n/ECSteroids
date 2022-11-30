using Core.Factories;
using Core.Game.Systems.View;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Infrastructure.Services.Pool;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Time;
using Infrastructure.Services.View;
using Infrastructure.Services.Windows;

namespace Core.Meta.Systems
{
    public sealed class RegisterServicesSystem : Feature
    {
        public RegisterServicesSystem(Contexts contexts, IViewService viewService, ITimeService timeService,
            IInputService inputService, ICameraProvider cameraProvider, IEnemyFactory enemyFactory,
            IWindowService windowService, IBulletFactory bulletFactory, IStaticDataService staticDataService, IRandomProvider randomProvider,
            IPoolService poolService)
        {
            Add(new RegisterViewServiceSystem(contexts, viewService));
            Add(new RegisterTimeServiceSystem(contexts, timeService));
            Add(new RegisterInputServiceSystem(contexts, inputService));
            Add(new RegisterPoolServiceSystem(contexts, poolService));
            Add(new RegisterCameraProviderSystem(contexts, cameraProvider));
            Add(new RegisterFactorySystem(contexts, enemyFactory, bulletFactory));
            Add(new RegisterWindowServiceSystem(contexts, windowService));
            Add(new RegisterStaticDataServiceSystem(contexts, staticDataService));
            Add(new RegisterRandomProviderSystem(contexts, randomProvider));
        }
    }
}