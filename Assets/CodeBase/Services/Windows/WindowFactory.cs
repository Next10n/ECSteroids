using Infrastructure.StateMachine;
using Services.AssetProvider;
using UI;
using UnityEngine;

namespace Services.Windows
{
    public class WindowFactory : IWindowFactory
    {
        private Canvas _rootCanvas;
        private IStateMachine _stateMachine;

        private readonly IAssetProvider _assetProvider;

        public WindowFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Initialize(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void InitCanvas()
        {
            _rootCanvas = Object.FindObjectOfType<Canvas>();
        }
        
        public PlayerHud CreateHud()
        {
            PlayerHud playerHud = _assetProvider.Load<PlayerHud>("Hud");
            return Object.Instantiate(playerHud, _rootCanvas.transform);
        }

        public ResultWindow CreateResultWindow()
        {
            ResultWindow resultWindow = _assetProvider.Load<ResultWindow>("ResultWindow");
            ResultWindow window = Object.Instantiate(resultWindow, _rootCanvas.transform);
            window.Construct(_stateMachine);
            return window;
        }
    }
}