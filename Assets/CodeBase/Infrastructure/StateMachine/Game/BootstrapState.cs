using Services.Windows;

namespace Infrastructure.StateMachine.Game
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IWindowFactory _windowFactory;

        public BootstrapState(IStateMachine stateMachine, IWindowFactory windowFactory)
        {
            _stateMachine = stateMachine;
            _windowFactory = windowFactory;
        }

        public void Enter()
        {
            _windowFactory.Initialize(_stateMachine);
            _stateMachine.Enter<LoadGameState>();
        }

        public void Exit()
        {
            
        }
    }
}