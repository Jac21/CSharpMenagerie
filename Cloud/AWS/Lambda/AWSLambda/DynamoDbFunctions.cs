using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Logging;

namespace AWSLambda
{
    public class DynamoDbFunctions
    {
        private readonly IAmazonDynamoDB _amazonDynamoDb;

        private readonly ILogger _logger;

        public int MaximumRetryCount { get; } = 3;

        public DynamoDbFunctions(IAmazonDynamoDB amazonDynamoDb, ILogger logger)
        {
            _amazonDynamoDb = amazonDynamoDb;

            _logger = logger;
        }

        public async Task<GetItemResponse> FetchAsync(GetItemRequest getItemRequest,
            CancellationToken cancellationToken)
        {
            var response = new GetItemResponse();

            var retryCount = 0;

            while (retryCount <= MaximumRetryCount)
            {
                try
                {
                    response = await _amazonDynamoDb.GetItemAsync(getItemRequest, cancellationToken);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);

                    retryCount += 1;

                    if (retryCount == MaximumRetryCount)
                    {
                        throw;
                    }

                    await Task.Delay((int) Math.Pow(1000, retryCount), cancellationToken);
                }
            }


            return response;
        }
    }
}