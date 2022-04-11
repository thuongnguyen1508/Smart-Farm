using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFarm.Models;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInputService _inputService;

        public StatisticController(ILogger<HomeController> logger,IInputService inputService)
        {
            _logger = logger;
            _inputService = inputService;
        }
        public async Task<IActionResult> ThonkeAsync()
        {
            var input=await _inputService.GetInputsAsync();
            InputAndOutputModel result=new InputAndOutputModel();
            result.Inputs=input;
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> InputAsync(int id)
        {
            var input=await _inputService.GetInputIdAsync(id);

            return View(input);
        }


        public IActionResult Output()
        {
            return View();
        }
    }
}
