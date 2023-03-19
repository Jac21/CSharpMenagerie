using Synchronizer.Interfaces;
using System;

namespace Synchronizer
{
    public class Program
    {
        public static void Foo(Synchronizer<MySharedClass, IReadFromShared, IWriteToShared> sync)
        {
            sync.Write(x =>
            {
                x.SetValue("new value");
            });

            sync.Read(x =>
            {
                Console.WriteLine(x.GetValue());
            });
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Synchronizer!");

            MySharedClass shared = new MySharedClass();
            var sync = new Synchronizer<MySharedClass, IReadFromShared, IWriteToShared>(shared);

            Foo(sync);

            Console.ReadLine();
        }
    }
}
