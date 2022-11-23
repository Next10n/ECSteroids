using Services.AssetProvider;
using UI;
using UnityEngine;

namespace Services.Windows
{
    public class WindowService : IWindowService
    {
        private Canvas _rootCanvas;
        private readonly IAssetProvider _assetProvider;

        public WindowService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
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
    }
}