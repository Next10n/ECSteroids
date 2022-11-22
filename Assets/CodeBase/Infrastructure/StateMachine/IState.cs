namespace Infrastructure.StateMachine
{
    public interface IGameplayState : IState
    {
        
    }
    public interface IGameState : IState
    {
        
    }
    public interface IState
    {
        void Enter();
        void Exit();
    }
}