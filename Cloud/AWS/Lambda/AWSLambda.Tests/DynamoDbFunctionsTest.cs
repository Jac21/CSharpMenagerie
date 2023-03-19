using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AWSLambda.Tests
{
    [TestFixture]
    public class DynamoDbFunctionsTest
    {
        private IAmazonDynamoDB _amazonDynamoDb;

        private ILoggerFactory _factory;

        private DynamoDbFunctions _dynamoDbFunctions;

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

            var logger = _factory.CreateLogger<DynamoDbFunctions>();

            _amazonDynamoDb = new AmazonDynamoDBClient(RegionEndpoint.USWest2);

            _dynamoDbFunctions =
                new DynamoDbFunctions(_amazonDynamoDb, logger);
        }

        [Test]
        public async Task DynamoDbFunctions_CreateAndListEc2Environments_Success_Test()
        {
            // arrange

            // act
            var response = await _dynamoDbFunctions.FetchAsync(
                new GetItemRequest("test-table", new Dictionary<string, AttributeValue>()), new CancellationToken());

            // assert
            Assert.IsNotNull(response.Item);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _factory.Dispose();
        }
    }
}