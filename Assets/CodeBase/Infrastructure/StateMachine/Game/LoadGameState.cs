using Services.SceneProvider;

namespace Infrastructure.StateMachine.Game
{
    public class LoadGameState : IGameState
    {
        private const string GameScene = "Game";
        private readonly ISceneProvider _sceneProvider;
        private readonly IStateMachine _stateMachine;

        public LoadGameState(ISceneProvider sceneProvider, IStateMachine stateMachine)
        {
            _sceneProvider = sceneProvider;
            _stateMachine = stateMachine;
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
            _stateMachine.Enter<GameLoopState>();
        }
    }
}