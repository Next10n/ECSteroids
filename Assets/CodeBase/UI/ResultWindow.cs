using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private Button _restartButton;
        
        private IStateMachine _gameStateMachine;
        private Contexts _contexts;

        public void Construct(Contexts contexts, IStateMachine gameplayStateMachine)
        {
            _contexts = contexts;
            _gameStateMachine = gameplayStateMachine;
        }

        private void OnEnable() => 
            _restartButton.onClick.AddListener(RestartGame);

        private void OnDisable() => 
            _restartButton.onClick.RemoveListener(RestartGame);

        private void RestartGame() => 
            _gameStateMachine.Enter<RestartState, Contexts>(_contexts);
    }
}