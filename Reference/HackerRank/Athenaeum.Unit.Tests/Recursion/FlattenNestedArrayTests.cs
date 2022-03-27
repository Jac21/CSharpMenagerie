using Athenaeum.Recursion;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Recursion
{
    public class FlattenNestedArrayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FlattenNestedArray_SimpleCase_Success()
        {
            // arrange
            var source = new object[] {
                "foo", 2, new int[] { 1, 2, 3, 4 }, "bar" };

            // act
            var simpleCase = FlattenNestedArray.FlattenArray(source);

            // assert
            Assert.AreEqual(new object[] { "foo", 2, 1, 2, 3, 4, "bar" }, simpleCase);
        }

        [Test]
        public void FlattenNestedArrayRecursive_SimpleCase_Success()
        {
            // arrange
            var source = new object[] {
                "foo", 2, new int[] { 1, 2, 3, 4 }, "bar" };

            // act
            var simpleCase = FlattenNestedArray.FlattenNestedArrayRecursive(source);

            // assert
            Assert.AreEqual(new object[] { "foo", 2, 1, 2, 3, 4, "bar" }, simpleCase);
        }

        [Test]
        public void FlattenNestedIntegerArrayRecursive_SimpleCase_Success()
        {
            // arrange
            var source = new object[]
            {
                1, 8, new object[] {6, 2, new int[] {9}, 8}, 2, 6
            };

            // act
            var simpleCase = FlattenNestedArray.FlattenNestedArrayRecursive(source);

            // assert
            Assert.AreEqual(new object[] { 1, 8, 6, 2, 9, 8, 2, 6 }, simpleCase);
        }
    }

    public class FlattenExtensionsTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FlattenExtensions_SimpleCase_Success()
        {
            // arrange
            var source = new object[]
            {
                1, 8, new object[] {6, 2, new object[] {9}, 8}, 2, 6
            };

            // act
            var simpleCase = FlattenExtensions.Flatten(source);

            // assert
            Assert.AreEqual(new object[] { 1, 8, 6, 2, 9, 8, 2, 6 }, simpleCase);
        }
    }
}
