using Game.Factories;
using Services;

namespace Infrastructure.StateMachine.Gameplay
{
    public class BootstrapGameplayState : IGameplayState
    {
        private readonly DiContainer _diContainer;
        private readonly Contexts _contexts;
        
        private IPlayerFactory _playerFactory;
        private IEnemyFactory _enemyFactory;

        public BootstrapGameplayState(Contexts contexts)
        {
            _diContainer = DiContainer.Instance;
            _contexts = contexts;
            RegisterServices();
        }

        private void RegisterServices()
        {
            _playerFactory = _diContainer.Register<IPlayerFactory, PlayerFactory>(new PlayerFactory(_contexts));
            _enemyFactory = _diContainer.Register<IEnemyFactory, EnemyFactory>(new EnemyFactory(_diContainer.Resolve<IRandomProvider>(), 
                _diContainer.Resolve<ICameraProvider>(), _contexts.game));
        }

        public void Enter()
        {
            GameEntity player = _playerFactory.Create();
            _enemyFactory.Initialize(player.creationIndex);
            // TODO Create Hud
        }

        public void Exit()
        {
            
        }
    }
}