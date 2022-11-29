using Infrastructure.Services.UpdateService;

namespace Infrastructure.Services.Ecs
{
    public interface IEcsService : ILateUpdatable, IUpdatable
    {
        Contexts CreateEcsWorld();
    }
}