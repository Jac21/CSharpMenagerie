using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings
{
    public class StringAdderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringAdder_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = StringAdder.AddStrings("11", "123");

            // assert
            Assert.AreEqual("134", simpleCase);
        }

        [Test]
        public void StringAdder_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCase = StringAdder.AddStrings("456", "77");

            // assert
            Assert.AreEqual("533", simpleCase);
        }

        [Test]
        public void StringAdder_SimpleCaseThree_Success()
        {
            // arrange

            // act
            var simpleCase = StringAdder.AddStrings("0", "0");

            // assert
            Assert.AreEqual("0", simpleCase);
        }
    }
}
