using System.Threading.Tasks;

namespace DotNetCoreWebApiBestPractices.Services.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrderAsync();
    }
}