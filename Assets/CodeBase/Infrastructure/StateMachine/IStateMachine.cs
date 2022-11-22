using Services;

namespace Infrastructure.StateMachine
{
    public interface IStateMachine : IService
    {
        void Enter<T>() where T : IState;
    }
}