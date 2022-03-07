using Athenaeum.Recursion;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Recursion;

public class EncryptedWordsTests

{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EncryptesWords_SimpleCase_Success()
    {
        // arrange
        const string input = "abc";

        // act
        var simpleCase = EncryptedWords.FindEncryptedWord(input);

        // assert
        Assert.AreEqual("bac", simpleCase);
    }

    [Test]
    public void EncryptesWords_SimpleCaseTwo_Success()
    {
        // arrange
        const string input = "abcd";

        // act
        var simpleCase = EncryptedWords.FindEncryptedWord(input);

        // assert
        Assert.AreEqual("bacd", simpleCase);
    }

    [Test]
    public void EncryptesWords_SimpleCaseThree_Success()
    {
        // arrange
        const string input = "abcxcba";

        // act
        var simpleCase = EncryptedWords.FindEncryptedWord(input);

        // assert
        Assert.AreEqual("xbacbca", simpleCase);
    }

    [Test]
    public void EncryptesWords_SimpleCaseFour_Success()
    {
        // arrange
        const string input = "facebook";

        // act
        var simpleCase = EncryptedWords.FindEncryptedWord(input);

        // assert
        Assert.AreEqual("eafcobok", simpleCase);
    }
}