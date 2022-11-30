using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.StateMachine;
using UnityEngine;
using View.UI;

namespace Infrastructure.Services.Windows
{
    public class WindowFactory : IWindowFactory
    {
        private Canvas _rootCanvas;
        private IStateMachine _stateMachine;

        private readonly IAssetProvider _assetProvider;
        private Contexts _contexts;

        public WindowFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Initialize(IStateMachine stateMachine, Contexts contexts)
        {
            _contexts = contexts;
            _stateMachine = stateMachine;
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
            window.Construct(_contexts, _stateMachine);
            return window;
        }
    }
}