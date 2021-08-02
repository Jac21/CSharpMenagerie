using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Logging;

namespace AWSLambda
{
    public class AmazonSqsFunctions
    {
        private readonly IAmazonSQS _amazonSqs;

        private readonly ILogger _logger;

        public AmazonSqsFunctions(IAmazonSQS amazonSqs, ILogger logger)
        {
            _amazonSqs = amazonSqs ?? throw new ArgumentNullException(nameof(amazonSqs));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task ShowQueues()
        {
            var attributes = new List<string>
            {
                QueueAttributeName.All
            };

            var listQueuesResponse = await _amazonSqs.ListQueuesAsync(string.Empty);

            foreach (var queueUrl in listQueuesResponse.QueueUrls)
            {
                var responseGetAtt = await _amazonSqs.GetQueueAttributesAsync(queueUrl, attributes);

                _logger.LogInformation($"Queue: {queueUrl}");

                foreach (var (key, value) in responseGetAtt.Attributes)
                {
                    _logger.LogInformation($"\t{key}: {value}");
                }
            }
        }

        public async Task<string> CreateQueue(string queueName, string deadLetterQueueUrl = null,
            string maxReceiveCount = null, string receiveWaitTime = null)
        {
            var attributes = new Dictionary<string, string>();

            // if a dead-letter queue is given, create a message queue
            if (!string.IsNullOrEmpty(deadLetterQueueUrl))
            {
                attributes.Add(QueueAttributeName.ReceiveMessageWaitTimeSeconds, receiveWaitTime);

                attributes.Add(QueueAttributeName.RedrivePolicy,
                    $"{{\"deadLetterTargetArn\":\"{await GetQueueArn(deadLetterQueueUrl)}\"," +
                    $"\"maxReceiveCount\":\"{maxReceiveCount}\"}}");
            }

            var creationResponse = await _amazonSqs.CreateQueueAsync(new CreateQueueRequest
            {
                QueueName = queueName,
                Attributes = attributes
            });

            return creationResponse.QueueUrl;
        }

        private async Task<string> GetQueueArn(string queueUrl)
        {
            var response = await _amazonSqs.GetQueueAttributesAsync(queueUrl, new List<string>
            {
                QueueAttributeName.QueueArn
            });

            return response.QueueARN;
        }
    }
}