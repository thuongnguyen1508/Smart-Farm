using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFarm.Models;
using SmartFarm.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customerService;
        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var loginSucess = await _customerService.LoginAsync(loginViewModel.UserName, loginViewModel.Password);

            if (!loginSucess)
            {
                loginViewModel.ErrorMessage = "Tài khoản không tồn tại";
                return View(loginViewModel);
            }

            return RedirectToAction("Home");
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult InforUser()
        {
            return View();
        }
        public IActionResult ManageDevice()
        {
            return View();
        }
    }
}
