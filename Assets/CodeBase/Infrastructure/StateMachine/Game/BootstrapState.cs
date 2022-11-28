using Infrastructure.StateMachine.Gameplay;
using Services.StaticData;

namespace Infrastructure.StateMachine.Game
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IStateMachine stateMachine , IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _staticDataService.Load();
            _stateMachine.Enter<LoadGameState>();
        }

        public void Exit()
        {
            
        }
    }
}