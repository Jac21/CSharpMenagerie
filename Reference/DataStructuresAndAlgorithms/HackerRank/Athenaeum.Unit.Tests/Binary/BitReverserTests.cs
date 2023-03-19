using System;
using Athenaeum.Binary;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Binary;

public class BitReverserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BitReverser_SimpleCase_Success()
    {
        // arrange
        var bits = Convert
            .ToUInt32("00000010100101000001111010011100", 2);

        // act
        var result = BitReverser.ReverseBits(bits);

        // assert
        Assert.AreEqual(964176192, result);
    }
    
    [Test]
    public void BitReverser_SimpleCaseTwo_Success()
    {
        // arrange
        var bits = Convert
            .ToUInt32("11111111111111111111111111111101", 2);

        // act
        var result = BitReverser.ReverseBits(bits);

        // assert
        Assert.AreEqual(3221225471, result);
    }

    [Test]
    public void BitReverser_SimpleCaseBitwise_Success()
    {
        // arrange
        var bits = Convert
            .ToUInt32("00000010100101000001111010011100", 2);

        // act
        var result = BitReverser.ReverseBitsBitwise(bits);

        // assert
        Assert.AreEqual(964176192, result);
    }
    
    [Test]
    public void BitReverser_SimpleCaseTwoBitwise_Success()
    {
        // arrange
        var bits = Convert
            .ToUInt32("11111111111111111111111111111101", 2);

        // act
        var result = BitReverser.ReverseBitsBitwise(bits);

        // assert
        Assert.AreEqual(3221225471, result);
    }
}