using Unit = System.ValueTuple;

namespace MyFunctionalLibrary
{
    public static partial class F
    {
        // convenience method that allows you to simply write return
        // Unit() in functions that return Unit
        public static Unit Unit() => default;
    }
}