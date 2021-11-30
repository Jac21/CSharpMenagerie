using System.Threading;
using System.Threading.Tasks;
using Amazon.Cloud9;
using Amazon.Cloud9.Model;
using Microsoft.Extensions.Logging;

namespace AWSLambda
{
    public class Cloud9Functions
    {
        private readonly IAmazonCloud9 _cloud9Client;

        private readonly ILogger _logger;

        public Cloud9Functions(IAmazonCloud9 cloud9Client, ILogger logger)
        {
            _cloud9Client = cloud9Client;

            _logger = logger;
        }

        public async Task<ListEnvironmentsResponse> CreateAndListEc2Environments(
            CreateEnvironmentEC2Request createEnvironmentEc2Request,
            ListEnvironmentsRequest listEnvironmentsRequest, CancellationToken cancellationToken)
        {
            await _cloud9Client.CreateEnvironmentEC2Async(createEnvironmentEc2Request, cancellationToken);

            return await _cloud9Client.ListEnvironmentsAsync(listEnvironmentsRequest, cancellationToken);
        }
    }
}