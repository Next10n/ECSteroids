using Infrastructure.Services.StateMachine.States;

namespace Infrastructure.Services.StateMachine
{
    public interface IStateMachine
    {
        void Enter<T>() where T : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}