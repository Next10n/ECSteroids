using UnityEngine;

namespace Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        GameObject Load(string assetPath);
        T Load<T>(string assetPath) where T : Object;
    }
}