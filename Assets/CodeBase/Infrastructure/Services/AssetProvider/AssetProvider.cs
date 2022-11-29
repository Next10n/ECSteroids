using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, Object> _storage = new Dictionary<string, Object>();
        public GameObject Load(string assetPath)
        {
            if (_storage.TryGetValue(assetPath, out Object value))
                return value as GameObject;

            GameObject prefab = Resources.Load<GameObject>(assetPath);
            _storage[assetPath] = prefab;
            return prefab;
        }
        
        public T Load<T>(string assetPath) where T : Object
        {
            if (_storage.TryGetValue(assetPath, out Object value))
                return value as T;

            T prefab = Resources.Load<T>(assetPath);
            _storage[assetPath] = prefab;
            return prefab;
        }
    }
}