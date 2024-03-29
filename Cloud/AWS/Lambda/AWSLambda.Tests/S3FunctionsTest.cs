using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Lambda.S3Events;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AWSLambda.Tests
{
    [TestFixture]
    public class S3FunctionsTest
    {
        private IAmazonS3 _s3Client;

        private ILoggerFactory _factory;

        private S3Functions _s3Functions;

        [OneTimeSetUp]
        public void Init()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.AddLambdaLogger();
                    builder.SetMinimumLevel(LogLevel.Debug);
                })
                .BuildServiceProvider();

            _factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = _factory.CreateLogger<S3FunctionsTest>();

            _s3Client = new AmazonS3Client(RegionEndpoint.USWest2);

            _s3Functions = new S3Functions(_s3Client, logger);
        }

        [Test]
        public async Task TestS3EventLambdaFunction()
        {
            // arrange
            const string key = "text.txt";
            var bucketName = await CreateTestBucket();

            try
            {
                await _s3Client.PutObjectAsync(new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    ContentBody = "sample data"
                });

                // Setup the S3 event object that S3 notifications would create with the fields used by the Lambda function.
                var s3Event = new S3Event
                {
                    Records = new List<S3EventNotification.S3EventNotificationRecord>
                    {
                        new S3EventNotification.S3EventNotificationRecord
                        {
                            S3 = new S3EventNotification.S3Entity
                            {
                                Bucket = new S3EventNotification.S3BucketEntity {Name = bucketName},
                                Object = new S3EventNotification.S3ObjectEntity {Key = key}
                            }
                        }
                    }
                };

                // act

                // Invoke the lambda function and confirm the content type was returned.
                var contentType = await _s3Functions.FunctionHandler(s3Event);

                Assert.AreEqual("text/plain", contentType);
            }
            finally
            {
                // Clean up the test data
                await AmazonS3Util.DeleteS3BucketWithObjectsAsync(_s3Client, bucketName);
            }
        }

        [Test]
        public async Task S3Functions_ListBucketsAsync_Success_Test()
        {
            // arrange
            CancellationToken cancellationToken = default;

            const string key = "text.txt";
            var bucketName = await CreateTestBucket();

            try
            {
                await _s3Client.PutObjectAsync(new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    ContentBody = "sample data"
                }, cancellationToken);

                // act
                var response = await _s3Functions.ListBucketsAsync(cancellationToken);

                // assert
                Assert.IsTrue(response.Buckets.Any(x =>
                    string.Equals(bucketName, x.BucketName, StringComparison.OrdinalIgnoreCase)));
            }
            finally
            {
                // Clean up the test data
                await AmazonS3Util.DeleteS3BucketWithObjectsAsync(_s3Client, bucketName, cancellationToken);
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _s3Client.Dispose();

            _factory.Dispose();
        }

        private async Task<string> CreateTestBucket()
        {
            var bucketName = "lambda-AWSLambda-".ToLower() + DateTime.Now.Ticks;

            // Create a bucket an object to setup a test data.
            await _s3Client.PutBucketAsync(bucketName);
            return bucketName;
        }
    }
}