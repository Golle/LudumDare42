using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Ioc
{
    internal class Container : IContainer
    {
        private readonly IDictionary<Type, ContainerObject> _containerObjects = new Dictionary<Type, ContainerObject>();

        public TTypeToResolve GetInstance<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }

        public IContainer Register<TTypeToResolve, TConcrete>() where TConcrete : TTypeToResolve
        {
            var typeToResolve = typeof(TTypeToResolve);
            if (_containerObjects.ContainsKey(typeToResolve))
            {
                throw new Exception($"The type {typeToResolve.Name} has already been registered.");
            }
            _containerObjects.Add(typeToResolve, new ContainerObject(typeof(TConcrete)));
            return this;
        }

        private object GetOrCreateInstance(ContainerObject containerObject)
        {
            if (containerObject.Instance != null)
            {
                return containerObject.Instance;
            }
            lock (containerObject)
            {
                return containerObject.Instance ?? CreateInstance(containerObject);
            }
        }

        private object CreateInstance(ContainerObject containerObject)
        {
            var parameters = ResolveConstructorParameters(containerObject);
            return containerObject.CreateInstance(parameters.ToArray());
        }

        private IEnumerable<object> ResolveConstructorParameters(ContainerObject containerObject)
        {
            return containerObject
                .Parameters
                .Select(parameter => ResolveObject(parameter.ParameterType));
        }

        private object ResolveObject(Type typeToResolve)
        {
            if (!_containerObjects.ContainsKey(typeToResolve))
            {
                throw new Exception($"The type {typeToResolve.Name} has not been registered.");
            }
            return GetOrCreateInstance(_containerObjects[typeToResolve]);
        }
    }
}