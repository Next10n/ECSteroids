using Infrastructure.Services.StateMachine;
using Infrastructure.Services.StateMachine.States;
using UI.View;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private ContextsView[] _contextsViews;
        
        private IStateMachine _gameStateMachine;
        private Contexts _contexts;

        public void Construct(Contexts contexts, IStateMachine gameplayStateMachine)
        {
            _contexts = contexts;
            _gameStateMachine = gameplayStateMachine;
            InitializeViews(contexts);
        }

        private void OnEnable() => 
            _restartButton.onClick.AddListener(RestartGame);

        private void OnDisable() => 
            _restartButton.onClick.RemoveListener(RestartGame);

        private void InitializeViews(Contexts contexts)
        {
            foreach(ContextsView contextsView in _contextsViews)
                contextsView.InitializeView(contexts);
        }

        private void RestartGame() => 
            _gameStateMachine.Enter<RestartState, Contexts>(_contexts);
    }
}