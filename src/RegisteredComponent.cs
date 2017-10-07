using System;

namespace IOC
{
    /// <summary>
    ///    A contract for registered dependencies (components).
    /// </summary>
    public interface IRegisteredComponent
    {
    }

    /// <summary>
    ///    Represents a registered dependency, that can be resolved at runtime.
    /// </summary>
    public class RegisteredComponent<T> : IRegisteredComponent
    {
        private static T Instance { get; set; }
        private Func<T> GetNew { get; set; }

        public RegisteredComponent(Func<T> getNew)
        {
            Get = GetNew = getNew;
        }

        public Func<T> Get { get; set; }

        /// <summary>
        ///    Registers current type as a singleton.
        /// </summary>
        public RegisteredComponent<T> AsSingleInstance()
        {
            Get = GetSingleInstance;
            return this;
        }

        private T GetSingleInstance()
        {
            if (Instance == null && GetNew != null)
            {
                Instance = GetNew();
            }
            return Instance;
        }
    }
}