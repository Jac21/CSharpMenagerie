using System.Collections.Generic;
using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings
{
    public class FindLongestWordTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindLongestWord_SimpleCase_Success()
        {
            // arrange
            var s = "abppplee";

            var d = new List<string>
            {
                "able", "ale", "apple", "bale", "kangaroo", "abppp", "abp"
            };

            // act
            var simpleCase = FindLongestWord.ExecuteBruteForce(s, d);

            // assert
            Assert.AreEqual("apple", simpleCase);
        }

        [Test]
        public void FindLongestWordInString_SimpleCase_Success()
        {
            // arrange
            var s = "abppplee";

            var d = new List<string>
            {
                "able", "ale", "apple", "bale", "kangaroo", "abppp", "abp"
            };

            // act
            var simpleCase = FindLongestWord.FindLongestWordInString(s, d);

            // assert
            Assert.AreEqual("apple", simpleCase);
        }
    }
}
