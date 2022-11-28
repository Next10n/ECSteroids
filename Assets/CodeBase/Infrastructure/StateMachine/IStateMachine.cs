using Services;

namespace Infrastructure.StateMachine
{
    public interface IStateMachine : IService
    {
        void Enter<T>() where T : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}