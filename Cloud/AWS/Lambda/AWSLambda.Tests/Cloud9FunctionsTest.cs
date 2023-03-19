using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.Cloud9;
using Amazon.Cloud9.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AWSLambda.Tests
{
    [TestFixture]
    public class Cloud9FunctionsTest
    {
        private IAmazonCloud9 _amazonCloud9Client;

        private ILoggerFactory _factory;

        private Cloud9Functions _cloud9Functions;

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

            var logger = _factory.CreateLogger<Cloud9Functions>();

            _amazonCloud9Client = new AmazonCloud9Client(RegionEndpoint.USWest2);

            _cloud9Functions =
                new Cloud9Functions(_amazonCloud9Client, logger);
        }

        [Test]
        public async Task Cloud9Functions_CreateAndListEc2Environments_Success_Test()
        {
            // arrange

            // act
            var response = await _cloud9Functions.CreateAndListEc2Environments(new CreateEnvironmentEC2Request
                {
                    Name = "LambdaC9Env"
                },
                new ListEnvironmentsRequest
                {
                    MaxResults = 10
                }, new CancellationToken(false));

            // assert
            Assert.IsTrue(response.EnvironmentIds.Any());
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _factory.Dispose();
        }
    }
}