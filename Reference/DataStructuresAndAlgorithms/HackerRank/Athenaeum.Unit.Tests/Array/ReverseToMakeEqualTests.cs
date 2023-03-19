using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array
{

    public class ReverseToMakeEqualTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReverseToMakeEqual_BaseCase_Success()
        {
            // arrange
            var inputA = new[]
            {
            7
        };

            var inputB = new[]
            {
            7
        };

            // act
            var baseCase = ReverseToMakeEqual.AreTheyEqual(inputA, inputB);

            // assert
            Assert.IsTrue(baseCase);
        }

        [Test]
        public void ReverseToMakeEqual_BaseCaseTwo_Success()
        {
            // arrange
            var inputA = new[]
            {
            7
        };

            var inputB = new[]
            {
            7, 7
        };

            // act
            var baseCase = ReverseToMakeEqual.AreTheyEqual(inputA, inputB);

            // assert
            Assert.IsFalse(baseCase);
        }

        [Test]
        public void ReverseToMakeEqual_SimpleCase_Success()
        {
            // arrange
            var inputA = new[]
            {
            1, 2, 3, 4
        };

            var inputB = new[]
            {
            1, 4, 3, 2
        };

            // act
            var simpleCase = ReverseToMakeEqual.AreTheyEqual(inputA, inputB);

            // assert
            Assert.IsTrue(simpleCase);
        }

        [Test]
        public void ReverseToMakeEqual_SimpleCaseTwo_Success()
        {
            // arrange
            var inputA = new[]
            {
            1, 2, 3, 4
        };

            var inputB = new[]
            {
            1, 4, 3, 3
        };

            // act
            var simpleCase = ReverseToMakeEqual.AreTheyEqual(inputA, inputB);

            // assert
            Assert.IsFalse(simpleCase);
        }
    }
}