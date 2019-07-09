using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LightPay.Services.Services
{
    public class UserService : IUserService
    {

        private readonly LightPayContext context;

        public UserService(LightPayContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateUserAsync(string username, string password, string name)
        {

            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }


            var user = new User()
            {
                Username = username,
                Password = result.ToString(),
                Name = name,

            };

            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();
            return user;
        }

        public async Task<User> FindUserAsync(string username, string password)
        {
            var user = await this.context.Users.SingleOrDefaultAsync(u => u.Username == username);

            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            if (user != null && user.Password == result.ToString())
            {
                return user;
            }

            return null;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await this.context.Users
                .ToListAsync();
        }

        public async Task<UsersAccounts> AddUserAccountAsync(Guid userId, Guid accountId)
        {
            var existUserAccount = await this.context.UsersAccounts
                .Where(ua => ua.UserId == userId)
               .SingleOrDefaultAsync(ua => ua.AccountId == accountId);

            if (existUserAccount != null)
            {
                throw new ArgumentException("This account is already registered for this user");
            }

            UsersAccounts userAccount = new UsersAccounts()
            {
                UserId = userId,
                AccountId = accountId
            };

            await this.context.UsersAccounts.AddAsync(userAccount);
            await this.context.SaveChangesAsync();
            return userAccount;
        }

    }
}
