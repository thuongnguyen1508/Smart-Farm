using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartFarm.Models;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class InputDeviceController : Controller
    {
        private readonly IInputService _inputService;
        public InputDeviceController(IInputService inputService)
        {
            _inputService = inputService;
        }
        [HttpGet]
        public async Task<IActionResult> SetUpNguong()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var input=await _inputService.GetInputsAsync();
            return View(input);
        }
        [HttpPost]
        public IActionResult SetNguong(InputModel input)
        {
            input.timeSet=TimeSpan.FromSeconds(input.secondTime);
            _inputService.UpdateSetNguong(input);
            return RedirectToAction("SetUpNguong");
        }

    }
}
