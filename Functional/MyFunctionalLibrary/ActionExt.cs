using System;

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
            return F.Unit();
        };

        public static Func<T, ValueTuple> ToFunc<T>(this Action<T> action) => (t) =>
        {
            action(t);
            return F.Unit();
        };
    }
}