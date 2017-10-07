using System;
using System.Collections.Concurrent;

namespace IOC
{
    /// <summary>
    ///    A simple implementation of DI (dependencies injector).
    /// </summary>
    public static class Injector
    {
        private static ConcurrentDictionary<Type, IRegisteredComponent> _registeredComponents = new ConcurrentDictionary<Type, IRegisteredComponent>();

        public static RegisteredComponent<T> Register<T>(Func<T> getNew)
        {
            var component = _registeredComponents.GetOrAdd(typeof(T), _ => new RegisteredComponent<T>(getNew));
            return component as RegisteredComponent<T>;
        }

        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (_registeredComponents.ContainsKey(type))
            {
                var component = _registeredComponents[type] as RegisteredComponent<T>;
                return component.Get();
            }
            throw new ComponentNotRegisteredException(type);
        }

        public static object Resolve(Type type)
        {
            if (_registeredComponents.ContainsKey(type))
            {
                dynamic component = _registeredComponents[type];
                return component.Get();
            }
            throw new ComponentNotRegisteredException(type);
        }
    }
}