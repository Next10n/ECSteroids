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
            DestroyEntities(contexts);
            _windowService.HideResult();
            GameEntity player = _playerFactory.Create(_staticDataService.PlayerStaticData);
            _windowService.InitializeHud(contexts, player);
        }

        private static void DestroyEntities(Contexts contexts)
        {
            GameEntity[] gameEntities = contexts.game.GetEntities();
            foreach(GameEntity gameEntity in gameEntities)
            {
                if(gameEntity.hasPosition)
                    gameEntity.isDestroyEntity = true;
            }
        }

        public void Exit()
        {
            
        }
    }
}