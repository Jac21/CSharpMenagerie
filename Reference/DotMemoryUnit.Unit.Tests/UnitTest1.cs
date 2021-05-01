using System.Collections.Generic;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace DotMemoryUnit.Unit.Tests
{
    public class DotMemoryUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DotMemoryUnit_CheckForObjects_Success_Test()
        {
            dotMemory.Check(memory =>
            {
                Assert.That(memory.GetObjects(where => where.Type
                        .Is<string>())
                    .ObjectsCount, Is.LessThanOrEqualTo(10_000));
            });
        }

        [DotMemoryUnit(CollectAllocations = true)]
        [Test]
        public void DotMemoryUnit_CheckMemoryTraffic_Success_Test()
        {
            var memoryCheckPointOne = dotMemory.Check();

            var stringList = new List<string>();

            for (var i = 0; i < 10_000; i++)
            {
                stringList.Add(i.ToString());
            }

            var memoryCheckPointTwo = dotMemory.Check(memory =>
            {
                Assert.That(memory.GetTrafficFrom(memoryCheckPointOne)
                    .Where(obj => obj.Type.Is<List<string>>())
                    .AllocatedMemory.SizeInBytes, Is.LessThan(2048));
            });
        }

        [DotMemoryUnit(CollectAllocations = true, SavingStrategy = SavingStrategy.OnAnyFail,
            Directory = @"C:\tmp\DotMemoryUnit", WorkspaceNumberLimit = 1)]
        [Test]
        public void DotMemoryUnit_CompareSnapshots_Success_Test()
        {
            var memoryCheckPoint = dotMemory.Check();

            var stringList = new List<string>();

            for (var i = 0; i < 10_000; i++)
            {
                stringList.Add(i.ToString());
            }

            dotMemory.Check(memory =>
            {
                Assert.That(memory.GetDifference(memoryCheckPoint)
                    .GetSurvivedObjects()
                    .GetObjects(where => where.Type.Is<List<string>>())
                    .ObjectsCount, Is.LessThan(15));
            });
        }
    }
}