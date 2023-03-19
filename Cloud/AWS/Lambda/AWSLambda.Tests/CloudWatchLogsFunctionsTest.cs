using System.Threading.Tasks;
using Amazon;
using Amazon.CloudWatchLogs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AWSLambda.Tests
{
    [TestFixture]
    public class CloudWatchLogsFunctionsTest
    {
        private IAmazonCloudWatchLogs _amazonCloudWatchLogs;

        private ILoggerFactory _factory;

        private CloudWatchLogsFunctions _cloudWatchLogsFunctions;

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

            var logger = _factory.CreateLogger<CloudWatchLogsFunctionsTest>();

            _amazonCloudWatchLogs = new AmazonCloudWatchLogsClient(RegionEndpoint.USWest2);

            _cloudWatchLogsFunctions =
                new CloudWatchLogsFunctions(_amazonCloudWatchLogs, logger);
        }

        [Test]
        public async Task CloudWatchLogsFunctions_DisplayLogGroupsWithPaginators_Success_Test()
        {
            // arrange

            // act
            await _cloudWatchLogsFunctions.DisplayLogGroupsWithPaginators();

            // assert
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _factory.Dispose();
        }
    }
}