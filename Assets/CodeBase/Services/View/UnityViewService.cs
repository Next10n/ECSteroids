using Entitas;
using Services.View;
using UnityEngine;

namespace Services.AssetProvider
{
    public class UnityViewService : IViewService
    {
        private readonly IAssetProvider _assetProvider;

        public UnityViewService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public IViewController CreateView(Contexts contexts, IEntity entity, string assetName)
        {
            GameObject prefab = _assetProvider.Load(assetName);
            IViewController view = prefab.GetComponent<IViewController>();
            view.InitializeView(contexts, entity);
            return view;
        }
    }
}