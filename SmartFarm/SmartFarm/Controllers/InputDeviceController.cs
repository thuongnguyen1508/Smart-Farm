using Microsoft.AspNetCore.Mvc;

namespace SmartFarm.Controllers
{
    public class InputDeviceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetUpNguong()
        {
            return View();
        }

    }
}
