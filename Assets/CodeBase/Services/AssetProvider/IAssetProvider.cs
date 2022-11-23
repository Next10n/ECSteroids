using UnityEngine;

namespace Services.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject Load(string assetPath);
        T Load<T>(string assetPath) where T : Object;
    }
}