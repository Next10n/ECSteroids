using System;
using System.Collections.Generic;

namespace Services
{
    public class DiContainer
    {
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        private static DiContainer _instance;

        private DiContainer()
        {
            _instance = this;
        }
        public static DiContainer Instance => _instance ?? new DiContainer();
        

        public TInterface Register<TInterface, TImplementation>(TImplementation service)
            where TInterface : class, IService
            where TImplementation : TInterface
        {
            _services[typeof(TInterface)] = service;
            return service;
        }

        public T Resolve<T>() where T : class, IService
        {
            return _services[typeof(T)] as T;
        }
    }
}