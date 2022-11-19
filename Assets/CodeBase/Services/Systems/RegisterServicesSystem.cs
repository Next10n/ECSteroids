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
        }
    }
}