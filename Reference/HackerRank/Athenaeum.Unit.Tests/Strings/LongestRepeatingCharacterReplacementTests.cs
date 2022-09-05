using System.Collections.Generic;
using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings;

public class LongestRepeatingCharacterReplacementTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LongestRepeatingCharacterReplacement_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = LongestRepeatingCharacterReplacement.CharacterReplacement("ABAB", 2);

        // assert
        Assert.AreEqual(4, simpleCase);
    }

    [Test]
    public void LongestRepeatingCharacterReplacement_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = LongestRepeatingCharacterReplacement.CharacterReplacement("AABABBA", 1);

        // assert
        Assert.AreEqual(4, simpleCase);
    }
}