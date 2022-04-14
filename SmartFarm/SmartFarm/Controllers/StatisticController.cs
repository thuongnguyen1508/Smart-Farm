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
        private readonly IOutputService _outputservice;
        private readonly ICustomerService _customerService;

        public StatisticController(ILogger<HomeController> logger,IInputService inputService, ICustomerService customerService,IOutputService outputService)
        {
            _logger = logger;
            _inputService = inputService;
            _customerService = customerService;
            _outputservice = outputService;
        }
        public async Task<IActionResult> ThonkeAsync(int idFarm)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            //var input=await _inputService.GetInputsAsync();
            //InputAndOutputModel result=new InputAndOutputModel();
            //result.Inputs=input;
            //return View(result);
            var equipment = await _customerService.GetEquipmentAsync(idFarm);
            return View(equipment);
        }
        [HttpGet]
        public async Task<IActionResult> InputAsync(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var input=await _inputService.GetInputIdAsync(id);
            return View(input);
        }

        [HttpGet]
        public IActionResult Output(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var result = _outputservice.GetOutputById(id);
            return View(result);
        }
    }
}
