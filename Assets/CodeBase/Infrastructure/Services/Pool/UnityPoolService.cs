using System.Collections.Generic;
using Infrastructure.Services.AssetProvider;
using UnityEngine;

namespace Infrastructure.Services.Pool
{
    public class UnityPoolService : IPoolService
    {
        private readonly Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();
        private readonly IAssetProvider _assetProvider;

        private Transform _poolsRoot;
        
        public UnityPoolService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Pool PreparePool(string asset, int size)
        {
            GameObject prefab = _assetProvider.Load(asset);
            GameObject poolRoot = new GameObject($"Pool : {asset}");
            poolRoot.transform.SetParent(GetOrCreateRoot());
            Pool pool = new Pool(poolRoot.transform, prefab, size);
            _pools[asset] = pool;
            return pool;
        }
        
        public PoolObject InjectPoolView(GameEntity gameEntity, string asset)
        {
            if(_pools.TryGetValue(asset, out Pool pool) == false) 
                pool = PreparePool(asset, 1);

            PoolObject injectPoolView = pool.Get();
            injectPoolView.InitializeView(gameEntity);
            return injectPoolView;
        }

        private Transform GetOrCreateRoot()
        {
            _poolsRoot = _poolsRoot != null ? _poolsRoot : new GameObject("Pools").transform;
            return _poolsRoot;
        }
    }
}