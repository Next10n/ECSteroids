using Services.View;

namespace Views.Systems
{
    public sealed class RegisterServicesSystem : Feature
    {
        public RegisterServicesSystem(Contexts contexts, DiContainer container)
        {
            Add(new RegisterViewServiceSystem(contexts, container.Resolve<IViewService>()));
        }
    }
}