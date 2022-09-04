using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class TrieTests
{
    [Test]
    public void Trie_SimpleCase_Success()
    {
        // arrange
        var trie = new Trie();
        trie.Insert("apple");

        // act
        var resultOne = trie.Search("apple");
        var resultTwo = trie.Search("app");
        var resultThree = trie.StartsWith("app");

        // arrange
        trie.Insert("app");

        // act
        var resultFour = trie.Search("app");

        // assert
        Assert.AreEqual(resultOne, true);
        Assert.AreEqual(resultTwo, false);
        Assert.AreEqual(resultThree, true);
        Assert.AreEqual(resultFour, true);
    }
}