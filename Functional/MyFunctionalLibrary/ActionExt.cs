using System;
using static MyFunctionalLibrary.F;

namespace MyFunctionalLibrary
{
    /// <summary>
    /// Adapter functions that convert an Action into a Unit-returning Func
    /// </summary>
    public static class ActionExt
    {
        public static Func<ValueTuple> ToFunc(this Action action) => () =>
        {
            action();
            return Unit();
        };

        public static Func<T, ValueTuple> ToFunc<T>(this Action<T> action) => (t) =>
        {
            action(t);
            return Unit();
        };
    }
}