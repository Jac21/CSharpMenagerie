using System;
using System.Diagnostics;
using Unit = System.ValueTuple;
using static MyFunctionalLibrary.ActionExt;

namespace MyFunctionalLibraryConsumers
{
    public static class Instrumentation
    {
        /// <summary>
        /// Includes an overload that takes an Action, converts the Action to a F
        /// unc<Unit> and passes it to the overload taking a Func<T>
        /// </summary>
        /// <param name="op"></param>
        /// <param name="act"></param>
        public static void Time(string op, Action act) => Time<Unit>(op, act.ToFunc());

        public static T Time<T>(string op, Func<T> f)
        {
            var sw = new Stopwatch();
            sw.Start();

            var t = f();

            sw.Stop();
            Console.WriteLine($"{op} took {sw.ElapsedMilliseconds}ms");
            return t;
        }
    }
}