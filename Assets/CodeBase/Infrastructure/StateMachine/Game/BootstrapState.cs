using Game.Factories;
using Infrastructure.StateMachine.Gameplay;
using Services;
using Services.AssetProvider;
using Services.Coroutine;
using Services.Input;
using Services.SceneProvider;
using Services.Time;
using Services.UpdateService;
using Services.View;
using Services.Windows;

namespace Infrastructure.StateMachine.Game
{
    public class BootstrapState : IGameState
    {
        private readonly DiContainer _diContainer;
        private readonly IStateMachine _stateMachine;

        public BootstrapState(DiContainer diContainer, IStateMachine stateMachine, UnityUpdateService updateService,
            CoroutineRunner coroutineRunner)
        {
            _diContainer = diContainer;
            _stateMachine = stateMachine;
            RegisterServices(updateService, coroutineRunner);
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadGameState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices(UnityUpdateService updateService, CoroutineRunner coroutineRunner)
        {
            _diContainer.Register<IAssetProvider, AssetProvider>(new AssetProvider());
            _diContainer.Register<IViewService, UnityViewService>(
                new UnityViewService(_diContainer.Resolve<IAssetProvider>()));
            _diContainer.Register<ITimeService, UnityTimeService>(new UnityTimeService());
            _diContainer.Register<IInputService, UnityInputService>(new UnityInputService());
            _diContainer.Register<ICameraProvider, UnityCameraProvider>(new UnityCameraProvider());
            _diContainer.Register<IRandomProvider, UnityRandomProvider>(new UnityRandomProvider());
            _diContainer.Register<ICoroutineRunner, CoroutineRunner>(coroutineRunner);
            _diContainer.Register<ISceneProvider, UnitySceneProvider>(
                new UnitySceneProvider(_diContainer.Resolve<ICoroutineRunner>()));
            _diContainer.Register<IUpdateService, UnityUpdateService>(updateService);
            _diContainer.Register<IWindowService, WindowService>(new WindowService(
                _diContainer.Resolve<IAssetProvider>(), _diContainer.Resolve<IGameplayStateMachine>()));
            _diContainer.Register<IPlayerFactory, PlayerFactory>(new PlayerFactory());
            _diContainer.Register<IEnemyFactory, EnemyFactory>(new EnemyFactory(_diContainer.Resolve<IRandomProvider>(),
                _diContainer.Resolve<ICameraProvider>()));
        }
    }
}