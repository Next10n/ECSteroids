using Services.Windows;

namespace Infrastructure.StateMachine.Game
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IWindowService _windowService;

        public BootstrapState(IStateMachine stateMachine, IWindowService windowService)
        {
            _stateMachine = stateMachine;
            _windowService = windowService;
        }

        public void Enter()
        {
            _windowService.Initialize(_stateMachine);
            _stateMachine.Enter<LoadGameState>();
        }

        public void Exit()
        {
            
        }
    }
}