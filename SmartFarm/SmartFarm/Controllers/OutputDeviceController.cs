using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class OutputDeviceController : Controller
    {
        private readonly IOutputService _output;
        public OutputDeviceController(IOutputService output){
            _output = output;
        }
        [HttpGet]
        public async Task<IActionResult> ControlDevice()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var outputs= await _output.GetOutputAsync();
            return View(outputs);
        }
        [HttpPost]

        public IActionResult UpdateAutoController(int i,int id)
        {
            _output.SetAutOutput(i,id);
           return RedirectToAction("ControlDevice"); 
        }
    }
}
