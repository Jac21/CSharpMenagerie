using PerfScratchpad.Refs;
using PerfScratchpad.Refs.ArrayPooledBlockingCollection;

namespace PerfScratchpad.Demonstrations;

public static class ArrayPooledBlockingCollectionDemonstrations
{
    // Demonstrates:
    //      BlockingCollection<T>.Add()
    //      BlockingCollection<T>.CompleteAdding()
    //      BlockingCollection<T>.TryTake()
    //      BlockingCollection<T>.IsCompleted
    public static void BC_TryTake(ArrayPooledBlockingCollection<IntEvent> bc)
    {
        // Construct and fill our BlockingCollection
        var NUMITEMS = 16_384;
        for (var i = 0; i < NUMITEMS; i++) bc.PublishEvent(i);
        // bc.CompleteAdding();
        var outerSum = 0;

        // Delegate for consuming the BlockingCollection and adding up all items
        var action = () =>
        {
            int localItem;
            var localSum = 0;

            // while (bc.TryTake(out localItem)) localSum += localItem;
            Interlocked.Add(ref outerSum, localSum);
        };

        // Launch three parallel actions to consume the BlockingCollection
        Parallel.Invoke(action, action, action);

        // Console.WriteLine("Sum[0..{0}) = {1}, should be {2}", NUMITEMS, outerSum, ((NUMITEMS * (NUMITEMS - 1)) / 2));
        // Console.WriteLine("bc.IsCompleted = {0} (should be true)", bc.IsCompleted);
    }
}