using BackgroundWorkerQueueExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using BackgroundWorkerQueueExample.Services;

namespace BackgroundWorkerQueueExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISlowApiService _slowApiService;

        public HomeController(ILogger<HomeController> logger, ISlowApiService slowApiService)
        {
            _logger = logger;
            _slowApiService = slowApiService;
        }

        public async Task<IActionResult> Index()
        {
            await _slowApiService.CallSlowApi(10_000);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}