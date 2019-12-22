using System;

namespace DependencyInjectionFromTheGroundUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IEngine
    {
    }

    public class Engine : IEngine
    {
        public int InstanceId { get; }

        public Engine()
        {
            InstanceId = new Random().Next();
        }
    }

    public interface IVehicle
    {
    }

    public class Car : IVehicle
    {
        private readonly IEngine _engine;

        public int InstanceId { get; }

        public Car(IEngine engine)
        {
            _engine = engine;
            InstanceId = new Random().Next();
        }
    }
}