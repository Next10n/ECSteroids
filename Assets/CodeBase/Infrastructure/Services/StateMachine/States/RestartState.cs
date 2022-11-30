using Core.Factories;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Windows;

namespace Infrastructure.Services.StateMachine.States
{
    public class RestartState : IPayloadState<Contexts>
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IWindowService _windowService;
        private readonly IStaticDataService _staticDataService;
        private readonly IEnemyFactory _enemyFactory;

        public RestartState(IPlayerFactory playerFactory, IWindowService windowService, IStaticDataService staticDataService, IEnemyFactory enemyFactory)
        {
            _playerFactory = playerFactory;
            _windowService = windowService;
            _staticDataService = staticDataService;
            _enemyFactory = enemyFactory;
        }

        public void Enter(Contexts contexts)
        {
            DestroyGameplayEntities(contexts);
            HideHud();
            ResetScore(contexts);
            GameEntity player = CreatePlayer();
            InitializeHud(contexts, player);
            InitializeFactory(contexts, player);
        }

        public void Exit()
        {
            
        }

        private void InitializeFactory(Contexts contexts, GameEntity player) => 
            _enemyFactory.Initialize(contexts.game, player.creationIndex);

        private void InitializeHud(Contexts contexts, GameEntity player) => 
            _windowService.InitializeHud(contexts, player);

        private GameEntity CreatePlayer() => 
            _playerFactory.Create(_staticDataService.PlayerStaticData);

        private static void ResetScore(Contexts contexts) => 
            contexts.game.scoreEntity.isResetScore = true;

        private void HideHud() => 
            _windowService.HideResult();

        private static void DestroyGameplayEntities(Contexts contexts)
        {
            foreach(GameEntity gameEntity in contexts.game.GetEntities())
                if(gameEntity.isEnemy || gameEntity.isBullet || gameEntity.isLaser)
                    gameEntity.isDestroyEntity = true;
        }
    }
}