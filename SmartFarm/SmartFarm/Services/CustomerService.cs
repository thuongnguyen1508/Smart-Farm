using Microsoft.AspNetCore.Identity;
using SmartFarm.Data;
using SmartFarm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly UserManager<Customer> _userManager;
        private readonly AppDbContext _context;
        public CustomerService(
            SignInManager<Customer> signInManager,
            UserManager<Customer> userManager,
            AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var customer = await _userManager.FindByNameAsync(username);
            if (customer == null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result.Succeeded;
        }
    }
}
