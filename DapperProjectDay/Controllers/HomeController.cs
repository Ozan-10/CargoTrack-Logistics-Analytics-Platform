using DapperProjectDay.Models;
using DapperProjectDay.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DapperProjectDay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboardService _dashboardService;

        public HomeController(
            ILogger<HomeController> logger,
            IDashboardService dashboardService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _dashboardService.GetStatisticsAsync();

            return View(values);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}