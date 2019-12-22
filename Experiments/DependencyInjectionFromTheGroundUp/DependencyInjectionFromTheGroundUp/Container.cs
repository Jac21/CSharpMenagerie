using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionFromTheGroundUp
{
    public class Container
    {
        private readonly IDictionary<Type, Registration> _registrations;

        public Container(IDictionary<Type, Registration> registrations)
        {
            _registrations = registrations;
        }

        public T Resolve<T>()
        {
            var t = typeof(T);
            return (T) Resolve(t);
        }

        public object Resolve(Type registeredType)
        {
            if (!_registrations.ContainsKey(registeredType))
            {
                throw new ArgumentException($"Type of {registeredType.Name} was not registered!");
            }

            var registration = _registrations[registeredType];
            var dependencies = registration.Dependencies.Select(Resolve).ToArray();

            return Activator.CreateInstance(registration.ToResolve, dependencies);
        }
    }
}