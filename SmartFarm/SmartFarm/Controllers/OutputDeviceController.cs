﻿using Microsoft.AspNetCore.Mvc;

namespace SmartFarm.Controllers
{
    public class OutputDeviceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ControlDevice()
        {
            return View();
        }
    }
}
