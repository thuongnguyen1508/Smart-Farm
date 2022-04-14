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
        private readonly ICustomerService _customerService;

        public StatisticController(ILogger<HomeController> logger,IInputService inputService, ICustomerService customerService)
        {
            _logger = logger;
            _inputService = inputService;
            _customerService = customerService;
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


        public IActionResult Output()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
    }
}
