using Services.SceneProvider;

namespace Infrastructure.StateMachine
{
    public class LoadGameState : IState
    {
        private const string GameScene = "Game";
        private readonly ISceneProvider _sceneProvider;
        private readonly IGameStateMachine _gameStateMachine;

        public LoadGameState(ISceneProvider sceneProvider, IGameStateMachine gameStateMachine)
        {
            _sceneProvider = sceneProvider;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _sceneProvider.Load(GameScene, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}