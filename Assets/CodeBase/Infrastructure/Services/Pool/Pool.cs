using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.Pool
{
    public class Pool
    {
        private readonly Transform _root;
        private readonly PoolObject _poolObject;

        private Queue<PoolObject> _poolObjects;

        public Pool(Transform root, PoolObject poolObject, int startSize)
        {
            _poolObject = poolObject;
            _root = root;
            Initialize(startSize);
        }

        public PoolObject Get()
        {
            if(_poolObjects.Count == 0) 
                AddToPool();
            PoolObject poolObject = _poolObjects.Dequeue();
            poolObject.InitializePool(this);
            poolObject.gameObject.SetActive(true);
            return poolObject;
        }

        public void Return(PoolObject poolObject)
        {
            poolObject.gameObject.SetActive(false);
            _poolObjects.Enqueue(poolObject);
        }

        private void Initialize(int startSize)
        {
            _poolObjects = new Queue<PoolObject>();
            for(int i = 0; i < startSize; i++) 
                AddToPool();
        }

        private void AddToPool()
        {
            PoolObject poolObject = Object.Instantiate(_poolObject, _root);
            poolObject.gameObject.SetActive(false);
            _poolObjects.Enqueue(poolObject);
        }
    }
}