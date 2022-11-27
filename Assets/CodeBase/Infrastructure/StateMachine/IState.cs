namespace Infrastructure.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IPayloadState<in TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState
    {
        void Exit();
    }
}