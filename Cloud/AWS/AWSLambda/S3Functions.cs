using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.S3Events;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda
{
    public class S3Functions
    {
        private readonly IAmazonS3 _s3Client;

        private readonly ILogger _logger;

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public S3Functions(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _s3Client = new AmazonS3Client(
                new AmazonS3Config
                {
                    Timeout = TimeSpan.FromSeconds(10),
                    RetryMode = RequestRetryMode.Standard,
                    MaxErrorRetry = 3
                });
        }

        /// <summary>
        /// Constructs an instance with a preconfigured S3 client. This can be used for testing the outside of the Lambda environment.
        /// </summary>
        /// <param name="s3Client"></param>
        /// <param name="logger"></param>
        public S3Functions(IAmazonS3 s3Client, ILogger logger)
        {
            _s3Client = s3Client ?? throw new ArgumentNullException(nameof(s3Client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// This method is called for every Lambda invocation. This method takes in an S3 event object and can be used 
        /// to respond to S3 notifications.
        /// </summary>
        /// <param name="evnt"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(S3Event evnt)
        {
            var s3Event = evnt.Records?[0].S3;

            if (s3Event == null)
            {
                return null;
            }

            try
            {
                var response = await _s3Client.GetObjectMetadataAsync(s3Event.Bucket.Name, s3Event.Object.Key);

                return response.Headers.ContentType;
            }
            catch (Exception e)
            {
                _logger.LogCritical(
                    $"Error getting object {s3Event.Object.Key} from bucket {s3Event.Bucket.Name}. Make sure they exist and your bucket is in the same region as this function.");

                _logger.LogCritical(e.Message);
                _logger.LogCritical(e.StackTrace);

                throw;
            }
        }

        public async Task<ListBucketsResponse> ListBucketsAsync(CancellationToken cancellationToken = default)
        {
            return await _s3Client.ListBucketsAsync(cancellationToken);
        }
    }
}