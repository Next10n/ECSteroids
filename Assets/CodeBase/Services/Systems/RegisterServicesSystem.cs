using Services.Input;
using Services.Time;
using Services.View;
using Views.Systems;

namespace Services.Systems
{
    public sealed class RegisterServicesSystem : Feature
    {
        public RegisterServicesSystem(Contexts contexts, DiContainer container)
        {
            Add(new RegisterViewServiceSystem(contexts, container.Resolve<IViewService>()));
            Add(new RegisterTimeServiceSystem(contexts, container.Resolve<ITimeService>()));
            Add(new RegisterInputServiceSystem(contexts, container.Resolve<IInputService>()));
            Add(new RegisterCameraProviderSystem(contexts, container.Resolve<ICameraProvider>()));
        }
    }
}