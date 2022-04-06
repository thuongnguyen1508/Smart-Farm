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
        public async Task<IActionResult> ControlDeviceAsync()
        {
            var outputs= await _output.GetOutputAsync();
            return View(outputs);
        }
    }
}
