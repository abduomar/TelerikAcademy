using LightPay.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightPay.Services.Interfaces
{
    public interface IAdministratorService
    {
        Task<Administrator> GetAdminAsync(string username, string password);
    }
}
