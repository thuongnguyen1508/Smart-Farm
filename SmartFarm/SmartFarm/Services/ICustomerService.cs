using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Services
{
    public interface ICustomerService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
