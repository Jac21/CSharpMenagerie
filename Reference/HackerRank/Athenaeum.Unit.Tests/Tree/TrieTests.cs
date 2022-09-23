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
    
    [Test]
    public void Trie_PrefixTreeStartsWith_SimpleCase_Success()
    {
        // arrange
        var prefixTreeStartsWith = new PrefixTreeStartsWith();
        prefixTreeStartsWith.Insert("apple");

        // act
        var resultOne = prefixTreeStartsWith.StartsWith("apple");
        var resultTwo = prefixTreeStartsWith.StartsWith("app");
        var resultThree = prefixTreeStartsWith.StartsWith("apc");

        // arrange
        prefixTreeStartsWith.Insert("app");

        // act
        var resultFour = prefixTreeStartsWith.StartsWith("app");

        // assert
        Assert.IsTrue(resultOne);
        Assert.IsTrue(resultTwo);
        Assert.IsFalse(resultThree);
        Assert.IsTrue(resultFour);
    }
}