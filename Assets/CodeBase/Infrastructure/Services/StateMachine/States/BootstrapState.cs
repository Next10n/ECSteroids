using Core.Factories;
using Infrastructure.Services.Ecs;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.UpdateService;

namespace Infrastructure.Services.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly IEcsService _ecsService;
        private readonly IUpdateService _updateService;
        private readonly IBulletFactory _bulletFactory;
        private readonly IPlayerFactory _playerFactory;

        public BootstrapState(IStateMachine stateMachine, IStaticDataService staticDataService, IEcsService ecsService,
            IUpdateService updateService, IBulletFactory bulletFactory, IPlayerFactory playerFactory)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _ecsService = ecsService;
            _updateService = updateService;
            _bulletFactory = bulletFactory;
            _playerFactory = playerFactory;
        }

        public void Enter()
        {
            _staticDataService.Load();
            Contexts contexts = _ecsService.CreateEcsWorld();
            _updateService.RegisterUpdatable(_ecsService);
            _bulletFactory.Initialize(contexts);
            _playerFactory.Initialize(contexts.game);
            _stateMachine.Enter<LoadGameState, Contexts>(contexts);
        }

        public void Exit()
        {
        }
    }
}