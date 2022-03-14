using Athenaeum.Strings;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Strings;

public class MatchingPairsFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MatchingPairsFinder_SimpleCase_Success()
    {
        // arrange
        const string s = "abcd";
        const string t = "adcb";

        // act
        var simpleCase = MatchingPairsFinder.MatchingPairs(s, t);

        // assert
        Assert.AreEqual(2, simpleCase);
    }

    [Test]
    public void MatchingPairsFinder_SimpleCaseThree_Success()
    {
        // arrange
        const string s = "ab";
        const string t = "ba";

        // act
        var simpleCase = MatchingPairsFinder.MatchingPairs(s, t);

        // assert
        Assert.AreEqual(0, simpleCase);
    }

    [Test]
    public void MatchingPairsFinder_SimpleCaseFour_Success()
    {
        // arrange
        const string s = "abcdx";
        const string t = "abxdc";

        // act
        var simpleCase = MatchingPairsFinder.MatchingPairs(s, t);

        // assert
        Assert.AreEqual(3, simpleCase);
    }
}