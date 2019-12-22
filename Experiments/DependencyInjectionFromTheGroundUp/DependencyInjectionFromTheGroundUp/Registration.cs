using System;

namespace DependencyInjectionFromTheGroundUp
{
    public class Registration
    {
        public Type Registered { get; set; }

        public Type ToResolve { get; set; }

        public Type[] Dependencies { get; set; }

        public Registration(Type registered, Type toResolve)
        {
            Registered = registered;
            ToResolve = toResolve;
        }
    }
}