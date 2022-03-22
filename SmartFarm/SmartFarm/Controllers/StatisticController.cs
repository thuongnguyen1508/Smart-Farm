using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmartFarm.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StatisticController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Thonke()
        {
            return View();
        }
        public IActionResult Input()
        {
            return View();
        }
        public IActionResult Output()
        {
            return View();
        }
    }
}
