using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings
{

    public class PalindromicSubstringsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LongestPalindromicSubstring_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = PalindromicSubstrings.CountSubstrings("abc");

            // assert
            Assert.AreEqual(3, simpleCase);
        }

        [Test]
        public void LongestPalindromicSubstring_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCaseTwo = PalindromicSubstrings.CountSubstrings("aaa");

            // assert
            Assert.AreEqual(6, simpleCaseTwo);
        }
    }
}