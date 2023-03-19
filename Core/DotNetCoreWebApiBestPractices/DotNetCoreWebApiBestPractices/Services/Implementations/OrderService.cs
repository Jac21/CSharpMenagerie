using System.Net.Http;
using System.Threading.Tasks;
using DotNetCoreWebApiBestPractices.Services.Interfaces;

namespace DotNetCoreWebApiBestPractices.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = "https://www.jeremycantu.com";
        }

        public async Task PlaceOrderAsync()
        {
            var uri = _remoteServiceBaseUrl;

            var responseString = await _httpClient
                .GetStringAsync(uri);
        }
    }
}