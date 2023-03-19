using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array
{

    public class PassingYearbooksTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CarPooler_SimpleCase_Success()
        {
            // arrange
            var input = new[]
            {
            2, 1
        };

            // act
            var simpleCase = PassingYearbooks.FindSignatureCounts(input);

            // assert
            Assert.AreEqual(new[] { 2, 2 }, simpleCase);
        }

        [Test]
        public void CarPooler_SimpleCaseTwo_Success()
        {
            // arrange
            var input = new[]
            {
            1, 2
        };

            // act
            var simpleCase = PassingYearbooks.FindSignatureCounts(input);

            // assert
            Assert.AreEqual(new[] { 1, 1 }, simpleCase);
        }
    }
}