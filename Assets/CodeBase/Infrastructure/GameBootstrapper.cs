using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game;
using Services;
using Services.Coroutine;
using Services.SceneProvider;
using Services.UpdateService;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private UnityUpdateService _updateService;
        [SerializeField] private CoroutineRunner _coroutineRunner;
        private void Awake()
        {
            DiContainer diContainer = DiContainer.Instance;
            GameStateMachine gameStateMachine = new GameStateMachine(diContainer, _updateService, _coroutineRunner);
            DontDestroyOnLoad(gameObject);
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}