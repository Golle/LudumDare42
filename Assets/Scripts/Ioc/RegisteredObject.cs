using System;
using System.Linq;
using System.Reflection;

namespace Assets.Scripts.Ioc
{
    internal class RegisteredObject
    {
        public Type ConcreteType { get; }
        public ParameterInfo[] Parameters { get; private set; }
        public RegisteredObject(Type concreteType)
        {
            if (concreteType == null)
            {
                throw new ArgumentNullException(nameof(concreteType));
            }
            ConcreteType = concreteType;
            SetParameters();
        }

        private void SetParameters()
        {
            var constructors = ConcreteType.GetConstructors();
            if (constructors.Length == 0)
            {
                throw new Exception($"Type {ConcreteType.Name} is missing a constructor");
            }

            if (constructors.Length > 1)
            {
                throw new Exception($"Type {ConcreteType.Name} have {constructors.Length} constructors defined. Only 1 is allowed.");
            }
            Parameters = constructors.First().GetParameters();
        }

        public object CreateInstance(params object[] args)
        {
            return Activator.CreateInstance(ConcreteType, args);
        }
    }
}