using System.Collections.Generic;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree
{
    public class NumberOfVisibleNodesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NodesInASubtree_SimpleCase_Success()
        {
            // arrange
            TreeNodeWrapper treeNodeWrapper = new(1);

            List<Query> queries = new()
            {
                new Query(1, 'a')
            };

            const string s = "aba";

            // act
            var simpleCase = NodesInASubtree.CountOfNodes(treeNodeWrapper, queries, s);

            // assert
            Assert.AreEqual(new[] { 2 }, simpleCase);
        }
    }
}