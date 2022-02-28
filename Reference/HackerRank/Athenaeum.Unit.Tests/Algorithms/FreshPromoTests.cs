using System.Collections.Generic;
using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class FreshPromoTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FreshPromo_SimpleCase_Success()
    {
        // arrange
        var codeList = new List<string>
        {
            "apple, apple",
            "banana, anything, banana"
        };

        var shoppingCart = new List<string>
        {
            "orange", "apple", "apple", "banana", "orange", "banana"
        };

        // act
        var results = FreshPromo.foo(codeList, shoppingCart);

        // assert
        Assert.AreEqual(1, results);
    }

    [Test]
    [Ignore("Need to keep track of overall ordering")]
    public void FreshPromo_SimpleCaseTwo_Success()
    {
        // arrange
        var codeList = new List<string>
        {
            "apple, apple",
            "banana, anything, banana"
        };

        var shoppingCart = new List<string>
        {
            "banana", "orange", "banana", "apple", "apple"
        };

        // act
        var results = FreshPromo.foo(codeList, shoppingCart);

        // assert
        Assert.AreEqual(0, results);
    }
}