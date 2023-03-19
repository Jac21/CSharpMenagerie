using System.Threading.Tasks;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using Microsoft.Extensions.Logging;

namespace AWSLambda
{
    public class CloudWatchLogsFunctions
    {
        private readonly IAmazonCloudWatchLogs _amazonCloudWatchLogsClient;

        private readonly ILogger _logger;

        public CloudWatchLogsFunctions(IAmazonCloudWatchLogs amazonCloudWatchLogsClient, ILogger logger)
        {
            _amazonCloudWatchLogsClient = amazonCloudWatchLogsClient;

            _logger = logger;
        }

        public async ValueTask DisplayLogGroupsWithPaginators()
        {
            var paginatorForResponses =
                _amazonCloudWatchLogsClient.Paginators.DescribeLogGroups(new DescribeLogGroupsRequest());

            await foreach (var response in paginatorForResponses.Responses)
            {
                _logger.LogInformation($"Content length: {response.ContentLength}");

                _logger.LogInformation($"HTTP result: {response.HttpStatusCode}");

                _logger.LogInformation($"Metadata: {response.ResponseMetadata}");

                _logger.LogInformation("Log groups:");

                foreach (var logGroup in response.LogGroups)
                {
                    _logger.LogInformation($"\t{logGroup.LogGroupName}");
                }
            }
        }
    }
}