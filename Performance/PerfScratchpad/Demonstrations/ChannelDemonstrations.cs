using System.Threading.Channels;

namespace PerfScratchpad.Demonstrations;

public static class ChannelDemonstrations
{
    public static async Task UnboundedProducerConsumerChannelDemo()
    {
        var channel = Channel.CreateUnbounded<int>();

        // producer
        _ = Task.Run(async () =>
        {
            for (int i = 0; i < 16_384; i++)
            {
                await channel.Writer.WriteAsync(i);
            }

            channel.Writer.Complete();
        });

        // consumer
        await foreach (var _ in channel.Reader.ReadAllAsync()) { }
    }
}