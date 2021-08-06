using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AWSLambda.Tests
{
    [TestFixture]
    public class AmazonSqsFunctionsTest
    {
        private IAmazonSQS _amazonSqs;

        private ILoggerFactory _factory;

        private AmazonSqsFunctions _amazonSqsFunctions;

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

            var logger = _factory.CreateLogger<AmazonSqsFunctionsTest>();

            _amazonSqs = new AmazonSQSClient(RegionEndpoint.USWest2);

            _amazonSqsFunctions =
                new AmazonSqsFunctions(_amazonSqs, logger);
        }

        [Test]
        public async Task AmazonSqsFunctions_ShowQueues_Success_Test()
        {
            // arrange

            // act
            await _amazonSqsFunctions.ShowQueues();

            // assert
        }
    }
}