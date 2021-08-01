using System.Threading.Tasks;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Microsoft.Extensions.Logging;

namespace AWSLambda
{
    public class CloudWatchLogsFunctions
    {
        private IAmazonCloudWatchLogs AmazonCloudWatchLogsClient { get; }

        public ILogger Logger { get; }

        public CloudWatchLogsFunctions(IAmazonCloudWatchLogs amazonCloudWatchLogsClient, ILogger logger)
        {
            AmazonCloudWatchLogsClient = amazonCloudWatchLogsClient;

            Logger = logger;
        }

        public async Task DisplayLogGroupsWithPaginators()
        {
            var paginatorForResponses =
                AmazonCloudWatchLogsClient.Paginators.DescribeLogGroups(new DescribeLogGroupsRequest());

            await foreach (var response in paginatorForResponses.Responses)
            {
                Logger.LogInformation($"Content length: {response.ContentLength}");

                Logger.LogInformation($"HTTP result: {response.HttpStatusCode}");

                Logger.LogInformation($"Metadata: {response.ResponseMetadata}");

                Logger.LogInformation("Log groups:");

                foreach (var logGroup in response.LogGroups)
                {
                    Logger.LogInformation($"\t{logGroup.LogGroupName}");
                }
            }
        }
    }
}