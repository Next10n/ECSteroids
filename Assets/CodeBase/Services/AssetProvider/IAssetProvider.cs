using UnityEngine;
using Views.Systems;

namespace Services.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject Load(string assetPath);
    }
}