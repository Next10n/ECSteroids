using System.Collections.Generic;
using UnityEngine;

namespace Services.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, GameObject> _storage = new Dictionary<string, GameObject>();
        public GameObject Load(string assetPath)
        {
            if (_storage.TryGetValue(assetPath, out GameObject value))
                return value;

            GameObject prefab = Resources.Load<GameObject>(assetPath);
            _storage[assetPath] = prefab;
            return prefab;
        }
    }
}