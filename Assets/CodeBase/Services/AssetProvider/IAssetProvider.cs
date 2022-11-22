using UnityEngine;

namespace Services.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject Load(string assetPath);
    }
}