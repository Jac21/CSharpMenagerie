using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Logging;

namespace AWSLambda
{
    public class AmazonSqsFunctions
    {
        private readonly IAmazonSQS _sqsClient;

        private readonly ILogger _logger;

        public AmazonSqsFunctions(IAmazonSQS amazonSqs, ILogger logger)
        {
            _sqsClient = amazonSqs ?? throw new ArgumentNullException(nameof(amazonSqs));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask ShowQueues()
        {
            var attributes = new List<string>
            {
                QueueAttributeName.All
            };

            var listQueuesResponse = await _sqsClient.ListQueuesAsync(string.Empty);

            foreach (var queueUrl in listQueuesResponse.QueueUrls)
            {
                await ShowAllAttributes(queueUrl, attributes);
            }
        }

        public async ValueTask<string> CreateQueue(string queueName, string deadLetterQueueUrl = null,
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

            var creationResponse = await _sqsClient.CreateQueueAsync(new CreateQueueRequest
            {
                QueueName = queueName,
                Attributes = attributes
            });

            return creationResponse.QueueUrl;
        }

        private async ValueTask DeleteQueue(string queueUrl)
        {
            _logger.LogInformation($"Deleting queue {queueUrl}...");

            try
            {
                await _sqsClient.DeleteQueueAsync(queueUrl);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Queue {queueUrl} was unable to be deleted!");
                _logger.LogCritical(e, string.Empty);

                throw;
            }

            _logger.LogInformation($"Queue {queueUrl} has been successfully deleted");
        }

        public async ValueTask SendMessage(string queueUrl, string messageBody)
        {
            var sendMessageResponse = await _sqsClient.SendMessageAsync(queueUrl, messageBody);

            _logger.LogInformation($"Message added to queue\n  {queueUrl}");
            _logger.LogInformation($"HttpStatusCode: {sendMessageResponse.HttpStatusCode}");
        }

        public async ValueTask UpdateAttribute(string queueUrl, string attribute, string value)
        {
            await _sqsClient.SetQueueAttributesAsync(queueUrl, new Dictionary<string, string>
            {
                {attribute, value}
            });
        }

        private async ValueTask ShowAllAttributes(string queueUrl, List<string> attributes)
        {
            var responseGetAtt = await _sqsClient.GetQueueAttributesAsync(queueUrl, attributes);

            _logger.LogInformation($"Queue: {queueUrl}");

            foreach (var (key, value) in responseGetAtt.Attributes)
            {
                _logger.LogInformation($"\t{key}: {value}");
            }
        }

        private static bool IsValidAttribute(string attribute)
        {
            var queueAttributeNameType = typeof(QueueAttributeName);

            var queueAttributeNameFields = queueAttributeNameType.GetFields()
                .Select(x => x.Name)
                .ToList();

            return queueAttributeNameFields.Any(x => x == attribute);
        }

        private async ValueTask<string> GetQueueArn(string queueUrl)
        {
            var response = await _sqsClient.GetQueueAttributesAsync(queueUrl, new List<string>
            {
                QueueAttributeName.QueueArn
            });

            return response.QueueARN;
        }

        public async Task Wait(int numMilliseconds, string queueUrl)
        {
            _logger.LogInformation($"Waiting for up to {numMilliseconds} milliseconds.");

            for (var i = 0; i < numMilliseconds; i++)
            {
                await Task.Delay(1000);

                var found = false;

                var responseList = await _sqsClient.ListQueuesAsync(string.Empty);

                foreach (var responseListQueueUrl in responseList.QueueUrls)
                {
                    if (string.Equals(queueUrl, responseListQueueUrl, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    break;
                }
            }
        }
    }
}