using System.Collections.Generic;
using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings;

public class MinimumWindowSubstringTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MinimumWindowSubstring_SimpleCase_Success()
    {
        // arrange
        const string s = "ADOBECODEBANC";

        const string t = "ABC";

        // act
        var simpleCase = MinimumWindowSubstring.MinWindow(s, t);

        // assert
        Assert.AreEqual("BANC", simpleCase);
    }

    [Test]
    public void MinimumWindowSubstring_SimpleCaseTwo_Success()
    {
        // arrange
        const string s = "a";

        const string t = "a";

        // act
        var simpleCase = MinimumWindowSubstring.MinWindow(s, t);

        // assert
        Assert.AreEqual("a", simpleCase);
    }

    [Test]
    public void MinimumWindowSubstring_SimpleCaseThree_Success()
    {
        // arrange
        const string s = "a";

        const string t = "aa";

        // act
        var simpleCase = MinimumWindowSubstring.MinWindow(s, t);

        // assert
        Assert.AreEqual(string.Empty, simpleCase);
    }
}