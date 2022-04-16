using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using SmartFarm.Services;

namespace SmartFarm.Views.Shared.Components.Auto
{
    [ViewComponent]
    public class AutoViewComponent:ViewComponent
    {
        private readonly IOutputService _output;
        private readonly UserManager<Customer> _userManager;
        public AutoViewComponent(IOutputService output,UserManager<Customer> userManager){
            _output = output;
            _userManager = userManager;
        }    
        public async Task<IViewComponentResult> InvokeAsync(int idFarm)
        {
            var outputs= await _output.GetOutputAsync(idFarm);
            return View<List<OutputModel>>(outputs);
        }
    }
}