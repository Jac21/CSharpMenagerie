using System.Collections.Concurrent;

namespace PerfScratchpad.Demonstrations;

public static class BlockingCollectionDemonstrations
{
    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.Take()
    //      BlockingCollection<T>.CompleteAdding()
    public static async Task BC_AddTakeCompleteAdding()
    {
        using var bc = new BlockingCollection<int>();

        // Spin up a Task to populate the BlockingCollection
        var t1 = Task.Run(() =>
        {
            bc.Add(1);
            bc.Add(2);
            bc.Add(3);
            bc.CompleteAdding();
        });

        // Spin up a Task to consume the BlockingCollection
        var t2 = Task.Run(() =>
        {
            // Consume the BlockingCollection
            while (true) bc.Take();
        });

        await Task.WhenAll(t1, t2);
    }

    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.CompleteAdding()
    //      BlockingCollection<T>.GetConsumingEnumerable()
    public static async Task BC_GetConsumingEnumerable()
    {
        using var bc = new BlockingCollection<int>();

        // Kick off a producer task
        var producerTask = Task.Run(async () =>
        {
            for (var i = 0; i < 16_384; i++)
            {
                bc.Add(i);
            }

            // Need to do this to keep foreach below from hanging
            bc.CompleteAdding();
        });

        // Now consume the blocking collection with foreach.
        // Use bc.GetConsumingEnumerable() instead of just bc because the
        // former will block waiting for completion and the latter will
        // simply take a snapshot of the current state of the underlying collection.
        foreach (var _ in bc.GetConsumingEnumerable())
        {
        }

        await producerTask; // Allow task to complete cleanup
    }

    // Demonstrates:
    //      Bounded BlockingCollection<T>
    //      BlockingCollection<T>.TryAddToAny()
    //      BlockingCollection<T>.TryTakeFromAny()
    public static void BC_FromToAny()
    {
        var bcs = new BlockingCollection<int>[2];
        bcs[0] = new BlockingCollection<int>(5); // collection bounded to 5 items
        bcs[1] = new BlockingCollection<int>(5); // collection bounded to 5 items

        // Should be able to add 10 items w/o blocking
        var numFailures = 0;
        for (var i = 0; i < 10; i++)
        {
            if (BlockingCollection<int>.TryAddToAny(bcs, i) == -1) numFailures++;
        }

        // Should be able to retrieve 10 items
        var numItems = 0;
        int item;
        while (BlockingCollection<int>.TryTakeFromAny(bcs, out item) != -1) numItems++;
    }

    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.CompleteAdding()
    //      BlockingCollection<T>.TryTake()
    //      BlockingCollection<T>.IsCompleted
    public static void BC_TryTake(BlockingCollection<int> bc)
    {
        // Construct and fill our BlockingCollection
        var NUMITEMS = 16_384;
        for (var i = 0; i < NUMITEMS; i++) bc.Add(i);
        bc.CompleteAdding();
        var outerSum = 0;

        // Delegate for consuming the BlockingCollection and adding up all items
        var action = () =>
        {
            var localSum = 0;

            while (bc.TryTake(out var localItem)) localSum += localItem;
            Interlocked.Add(ref outerSum, localSum);
        };

        // Launch three parallel actions to consume the BlockingCollection
        Parallel.Invoke(action, action, action);
    }
}