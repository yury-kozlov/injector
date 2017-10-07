using System;

namespace IOC
{
    [Serializable]
    public class ComponentNotRegisteredException : Exception
    {
        private Type type;

        public ComponentNotRegisteredException()
        {
        }

        public ComponentNotRegisteredException(Type type)
            : base($"Component {type} not registered")
        {
            this.type = type;
        }
    }
}