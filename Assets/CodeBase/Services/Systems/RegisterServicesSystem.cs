using Game.Factories;
using Services.Input;
using Services.Time;
using Services.View;

namespace Services.Systems
{
    public sealed class RegisterServicesSystem : Feature
    {
        public RegisterServicesSystem(Contexts contexts, IViewService viewService, ITimeService timeService,
            IInputService inputService, ICameraProvider cameraProvider, IEnemyFactory enemyFactory)
        {
            Add(new RegisterViewServiceSystem(contexts, viewService));
            Add(new RegisterTimeServiceSystem(contexts, timeService));
            Add(new RegisterInputServiceSystem(contexts, inputService));
            Add(new RegisterCameraProviderSystem(contexts, cameraProvider));
            Add(new RegisterFactorySystem(contexts, enemyFactory));
        }
    }
}