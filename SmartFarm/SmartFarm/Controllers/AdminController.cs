using Microsoft.AspNetCore.Mvc;

namespace SmartFarm.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ManageUser()
        {
            return View();
        }
        public IActionResult EditUser()
        {
            return View();
        }
    }
}
