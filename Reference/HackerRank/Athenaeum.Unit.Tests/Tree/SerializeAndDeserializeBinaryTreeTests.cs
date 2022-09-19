using System.Collections.Generic;
using System.Linq;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class SerializeAndDeserializeBinaryTreeTests
{
    private SerializeAndDeserializeBinaryTree _serializeAndDeserializeBinaryTree;

    [SetUp]
    public void Setup()
    {
        _serializeAndDeserializeBinaryTree = new SerializeAndDeserializeBinaryTree();
    }

    [Test]
    public void SerializeAndDeserializeBinaryTree_Serialize_Success()
    {
        // arrange

        // act
        var simpleCase = _serializeAndDeserializeBinaryTree.serialize(new TreeNode(1, new TreeNode(2),
            new TreeNode(3, new TreeNode(4), new TreeNode(5))));

        // assert
        Assert.IsTrue(simpleCase.Any());
    }

    [Test]
    public void SerializeAndDeserializeBinaryTree_Deserialize_Success()
    {
        // arrange
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(int
            .MinValue);
        queue.Enqueue(int
            .MinValue);
        queue.Enqueue(4);
        queue.Enqueue(5);

        // act
        var simpleCase = _serializeAndDeserializeBinaryTree.deserialize(queue);

        // assert
        Assert.IsNotNull(simpleCase);
    }
}