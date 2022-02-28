using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings;

public class LongestSubstringWithoutRepeatingCharactersTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LongestSubstringWithoutRepeatingCharacters_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring("abcabcbb");

        // assert
        Assert.AreEqual(3, simpleCase);
    }

    [Test]
    public void LongestSubstringWithoutRepeatingCharacters_BaseCase_Success()
    {
        // arrange

        // act
        var baseCase = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring("bbbbb");

        // assert
        Assert.AreEqual(1, baseCase);
    }

    [Test]
    public void LongestSubstringWithoutRepeatingCharacters_HardCase_Success()
    {
        // arrange

        // act
        var hardCase = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring("pwwkew");

        // assert
        Assert.AreEqual(3, hardCase);
    }
}