using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class OutputDeviceController : Controller
    {
        private readonly OutputService _output;
        public OutputDeviceController(OutputService output){
            _output = output;
        }
        public async Task<IActionResult> ControlDeviceAsync()
        {
            var outputs= await _output.GetOutputAsync();
            return View(outputs);
        }
    }
}
