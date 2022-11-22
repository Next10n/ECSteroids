using Views.Systems;

namespace Infrastructure.StateMachine
{
    public interface IUpdateService : IService
    {
        void RegisterUpdatable(IUpdatable updatable);
        void UnRegisterUpdatable(IUpdatable updatable);
        void RegisterLateUpdatable(ILateUpdatable lateUpdatable);
        void UnRegisterLateUpdatable(ILateUpdatable lateUpdatable);
    }
}