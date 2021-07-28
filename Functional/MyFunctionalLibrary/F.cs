using Unit = System.ValueTuple;

namespace MyFunctionalLibrary
{
    public static partial class F
    {
        // convenience method that allows you to simply write return
        // Unit() in functions that return Unit
        public static Unit Unit() => default;

        /// <summary>
        /// The "None" value
        /// </summary>
        public static Option.None None => Option.None.Default;

        /// <summary>
        /// The "Some" function wraps the given value into a "Some"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option.Some<T> Some<T>(T value) => new Option.Some<T>(value);
    }
}