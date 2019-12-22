using DependencyInjectionFromTheGroundUp;
using NUnit.Framework;

namespace DependencyInjection.Unit.Tests
{
    public class DependencyInjectionTests
    {
        [Test]
        public void Should_Be_Able_To_Resolve_An_Engine_Insance()
        {
            // arrange
            var builder = new ContainerBuilder();

            // act
            builder.Register<Engine>();

            var sut = builder.Build();
            var instance = sut.Resolve<Engine>();

            // assert
            Assert.NotNull(instance);
        }

        [Test]
        public void Should_Be_Able_To_Resolve_A_Car_Insance()
        {
            // arrange
            var builder = new ContainerBuilder();

            // act
            builder.Register<Car>();
            builder.Register<Engine>();

            var sut = builder.Build();
            var instance = sut.Resolve<Car>();

            // assert
            Assert.NotNull(instance);
        }

        [Test]
        public void Should_Be_Able_To_Resolve_A_Car_Insance_For_IVehicle_Interface()
        {
            // arrange
            var builder = new ContainerBuilder();

            // act
            builder.Register<IVehicle, Car>();
            builder.Register<IEngine, Engine>();

            var sut = builder.Build();
            var instance = sut.Resolve<IVehicle>();

            // assert
            Assert.NotNull(instance);
        }
    }
}