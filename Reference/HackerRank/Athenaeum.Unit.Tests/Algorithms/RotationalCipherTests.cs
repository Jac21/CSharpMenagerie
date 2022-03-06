using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class RotationalCipherTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RotateCipher_SimpleCase_Success()
    {
        // arrange
        const string input = "Zebra-493?";
        const int rotationFactor = 3;

        // act
        var result =
            RotationalCipher.RotateCipher(input, rotationFactor);

        // assert
        Assert.AreEqual("Cheud-726?", result);
    }
}