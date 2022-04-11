using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartFarm.Data;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Services
{
    public class CustomerService : ICustomerService
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
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public UserInforViewModel InforUser(string UserName)
        {
            var user = (from a in _context.Customer
                              where a.UserName == UserName
                              select new UserInforViewModel
                              {
                                  UserName = a.UserName,
                                  Ho = a.Ho,
                                  Ten = a.Ten,
                                  Address = a.DiaChi,
                                  Email = a.Email
                              }).FirstOrDefault();
            return user;
        }
        public void PostEditAccount(UserInforViewModel account)
        {
            var user = (from a in _context.Customer
                        where a.UserName == account.UserName
                        select a).FirstOrDefault();
            user.Ho = account.Ho;
            user.Ten = account.Ten;
            user.Email = account.Email;
            user.DiaChi = account.Address;
            _context.SaveChanges();
        }
        public async Task<bool> PostPassword(UserInforViewModel account)
        {
            var customer = (from a in _context.Customer
                            where a.UserName == account.UserName
                            select a.Id).FirstOrDefault();
            var customerID = customer.ToString();
            var user = await _userManager.FindByIdAsync(customerID);
            var result = await _userManager.ChangePasswordAsync(user, account.CurentPassword, account.Password);
            return result.Succeeded;
        }
    }
}