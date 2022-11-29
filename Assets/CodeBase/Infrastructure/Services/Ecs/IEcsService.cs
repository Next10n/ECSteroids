using Infrastructure.Services.UpdateService;

namespace Infrastructure.Services.Ecs
{
    public interface IEcsService : IUpdatable
    {
        Contexts CreateEcsWorld();
    }
}