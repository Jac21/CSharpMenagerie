using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionFromTheGroundUp
{
    public class ContainerBuilder
    {
        private readonly IList<Registration> _registrations = new List<Registration>();

        public void Register<T>()
        {
            Register<T, T>();
        }

        public void Register<TRegistered, TConcrete>()
        {
            _registrations.Add(new Registration(typeof(TRegistered), typeof(TConcrete)));
        }

        public Container Build()
        {
            foreach (var registration in _registrations)
            {
                var typeToAnalyze = registration.ToResolve;

                var constructorInfo = typeToAnalyze.GetConstructors().FirstOrDefault();

                registration.Dependencies = constructorInfo == null
                    ? new Type[0]
                    : constructorInfo.GetParameters().Select(pi => pi.ParameterType).ToArray();
            }

            return new Container(_registrations.ToDictionary(r => r.Registered));
        }
    }
}