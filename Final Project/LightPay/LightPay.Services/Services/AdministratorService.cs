using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LightPay.Services.Services
{
    public class AdministratorService : IAdministratorService
    {

        private readonly LightPayContext context;

        public AdministratorService(LightPayContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Administrator> GetAdminAsync(string username, string password)
        {
            var administrator = await this.context.Administrators.SingleOrDefaultAsync(u => u.Username == username);

            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            if (administrator != null && administrator.Password == result.ToString())
            {
                return administrator;
            }

            throw new ArgumentException();
        }
    }
}
