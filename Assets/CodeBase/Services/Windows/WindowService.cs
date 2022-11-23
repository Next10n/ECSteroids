using Infrastructure.StateMachine;
using Services.AssetProvider;
using UI;
using UnityEngine;

namespace Services.Windows
{
    public class WindowService : IWindowService
    {
        private Canvas _rootCanvas;
        private ResultWindow _resultWindow;

        private readonly IAssetProvider _assetProvider;
        private readonly IStateMachine _gameplayStateMachine;

        public WindowService(IAssetProvider assetProvider, IStateMachine gameplayStateMachine)
        {
            _assetProvider = assetProvider;
            _gameplayStateMachine = gameplayStateMachine;
        }

        public void Initialize()
        {
            _rootCanvas = Object.FindObjectOfType<Canvas>();
        }

        public PlayerHud CreateHud()
        {
            PlayerHud hud = _assetProvider.Load<PlayerHud>("Hud");
            return Object.Instantiate(hud, _rootCanvas.transform);
        }

        public void ShowResult()
        {
            if (_resultWindow == null)
                _resultWindow = CreateResultWindow();
            else
                _resultWindow.gameObject.SetActive(true);
        }

        public void HideResult() => 
            _resultWindow.gameObject.SetActive(false);

        private ResultWindow CreateResultWindow()
        {
            ResultWindow resultWindow = _assetProvider.Load<ResultWindow>("ResultWindow");
            ResultWindow window = Object.Instantiate(resultWindow, _rootCanvas.transform);
            window.Construct(_gameplayStateMachine);
            return window;
        }
    }
}