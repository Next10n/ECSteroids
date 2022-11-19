using System;
using System.Collections.Generic;
using UnityEngine;

namespace Views.Systems
{
    public class DiContainer
    {
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public void Register<TInterface, TImplementation>(TImplementation service) 
            where TInterface : class, IService
            where TImplementation : TInterface
        {
            _services[typeof(TInterface)] = service;
        }

        public T Resolve<T>() where T : class, IService
        {
            return _services[typeof(T)] as T;
        }
    }
}