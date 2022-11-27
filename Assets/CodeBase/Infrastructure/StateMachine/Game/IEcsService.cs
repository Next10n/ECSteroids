using Services.UpdateService;

namespace Infrastructure.StateMachine.Game
{
    public interface IEcsService : ILateUpdatable, IUpdatable
    {
        Contexts CreateEcsWorld();
    }
}