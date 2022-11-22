using Game.Factories;

namespace Infrastructure.StateMachine.Gameplay
{
    public class BootstrapGameplayState : IGameplayState
    {
        private readonly Contexts _contexts;
        
        private readonly IPlayerFactory _playerFactory;
        private readonly IEnemyFactory _enemyFactory;

        public BootstrapGameplayState(Contexts contexts, IPlayerFactory playerFactory, IEnemyFactory enemyFactory)
        {
            _contexts = contexts;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }
        
        public void Enter()
        {
            _playerFactory.Initialize(_contexts.game);
            GameEntity player = _playerFactory.Create();
            _enemyFactory.Initialize(_contexts.game, player.creationIndex);
            CreateSpawners();
            // TODO Create Hud
            // TODO Create Spawners
        }

        private void CreateSpawners()
        {
            GameEntity asteroidSpawner = _contexts.game.CreateEntity();
        }

        public void Exit()
        {
            
        }
    }
}