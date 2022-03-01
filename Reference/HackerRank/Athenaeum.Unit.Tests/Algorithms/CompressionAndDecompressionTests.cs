using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class CompressionAndDecompressionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CompressionAndDecompression_SimpleCase_Success()
    {
        // arrange
        const string input = "10[a]";

        // act
        var result =
            CompressionAndDecompression.DecompressString(input);

        // assert
        Assert.AreEqual("aaaaaaaaaa", result);
    }

    [Test]
    public void CompressionAndDecompression_SimpleCaseTwo_Success()
    {
        // arrange
        const string input = "3[abc]4[ab]c";

        // act
        var result =
            CompressionAndDecompression.DecompressString(input);

        // assert
        Assert.AreEqual("abcabcabcababababc", result);
    }
}