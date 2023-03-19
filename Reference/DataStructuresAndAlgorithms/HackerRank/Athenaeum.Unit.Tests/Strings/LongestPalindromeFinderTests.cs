using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings;

public class LongestPalindromeFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LongestPalindrome_SimpleCase_Success()
    {
        // arrange
        const string s = "babad";

        // act
        var simpleCase = LongestPalindromeFinder.LongestPalindrome(s);

        // assert
        Assert.AreEqual("bab", simpleCase);
    }

    [Test]
    public void LongestPalindrome_SimpleCaseTwo_Success()
    {
        // arrange
        const string s = "cbbd";

        // act
        var simpleCaseTwo = LongestPalindromeFinder.LongestPalindrome(s);

        // assert
        Assert.AreEqual("bb", simpleCaseTwo);
    }
}