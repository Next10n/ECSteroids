using Infrastructure.StateMachine;
using Services;
using Services.SceneProvider;
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