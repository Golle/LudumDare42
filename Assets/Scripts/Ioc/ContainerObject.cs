using System;
using System.Reflection;

namespace Assets.Scripts.Ioc
{
    internal class ContainerObject
    {
        public ParameterInfo[] Parameters => _registeredObject.Parameters;
        public Type ConcreteType => _registeredObject.ConcreteType;
        public object Instance { get; private set; }
        private readonly RegisteredObject _registeredObject;
        public ContainerObject(Type concreteType, object instance = null)
        {
            _registeredObject = new RegisteredObject(concreteType);
            Instance = instance;
        }

        public object CreateInstance(params object[] args)
        {
            return Instance = _registeredObject.CreateInstance(args);
        }
    }
}