using Infrastructure.Services.AssetProvider;
using UI.View;
using UnityEngine;

namespace Infrastructure.Services.View
{
    public class UnityViewService : IViewService
    {
        private readonly IAssetProvider _assetProvider;

        public UnityViewService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateView(GameEntity entity, string assetName)
        {
            GameObject prefab = _assetProvider.Load(assetName);
            GameObject instantiate = Object.Instantiate(prefab);
            UnityGameView[] unityGameViews = instantiate.GetComponents<UnityGameView>();
            foreach (UnityGameView unityGameView in unityGameViews)
                unityGameView.InitializeView(entity);
        }
    }
}