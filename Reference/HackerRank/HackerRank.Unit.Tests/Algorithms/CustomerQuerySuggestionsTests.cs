using System.Collections.Generic;
using System.Linq;
using HackerRank.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class CustomerQuerySuggestionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CustomerQuerySuggestions_SimpleCase_Success()
    {
        // arrange
        var repository = new List<string>
        {
            "mobile", "mouse", "moneypot", "monitor", "mousepad"
        };

        // act
        var results =
            CustomerQuerySuggestions.searchSuggestions(repository, "mouse");

        // assert
        Assert.IsTrue(results.Any());
    }
}