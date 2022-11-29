using Game.Factories;
using Services.StaticData;
using Services.Windows;

namespace Infrastructure.StateMachine.Gameplay
{
    public class RestartState : IPayloadState<Contexts>
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IWindowService _windowService;
        private readonly IStaticDataService _staticDataService;

        public RestartState(IPlayerFactory playerFactory, IWindowService windowService, IStaticDataService staticDataService)
        {
            _playerFactory = playerFactory;
            _windowService = windowService;
            _staticDataService = staticDataService;
        }

        public void Enter(Contexts contexts)
        {
            DestroyEnemies(contexts);
            HideHud();
            ResetScore(contexts);
            InitializeHud(contexts, CreatePlayer());
        }

        public void Exit()
        {
            
        }

        private void InitializeHud(Contexts contexts, GameEntity player) => 
            _windowService.InitializeHud(contexts, player);

        private GameEntity CreatePlayer() => 
            _playerFactory.Create(_staticDataService.PlayerStaticData);

        private static void ResetScore(Contexts contexts) => 
            contexts.game.scoreEntity.isResetScore = true;

        private void HideHud() => 
            _windowService.HideResult();

        private static void DestroyEnemies(Contexts contexts)
        {
            foreach(GameEntity gameEntity in contexts.game.GetEntities())
                if(gameEntity.isEnemy)
                    gameEntity.isDestroyEntity = true;
        }
    }
}