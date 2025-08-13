using System.Threading.Tasks.Dataflow;

namespace PerfScratchpad.Demonstrations;

public static class DataflowDemonstrations
{
    public static async Task BufferBlockDemo()
    {
        var bufferBlock = new BufferBlock<int>();

        for (var i = 0; i < 1_024; i++)
        {
            var task = bufferBlock.ReceiveAsync();

            bufferBlock.Post(i);

            await task;
        }
    }
}