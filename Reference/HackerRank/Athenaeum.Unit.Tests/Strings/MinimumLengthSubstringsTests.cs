using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings;

public class MinimumLengthSubstringsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MinimumLengthSubstrings_SimpleCase_Success()
    {
        // arrange
        const string s = "dcbefebce";
        const string t = "fd";

        // act
        var simpleCase = MinimumLengthSubstrings.MinLengthSubstring(s, t);

        // assert
        Assert.AreEqual(5, simpleCase);
    }
}