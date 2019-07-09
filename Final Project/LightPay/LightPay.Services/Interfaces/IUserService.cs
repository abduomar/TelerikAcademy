using LightPay.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightPay.Services.Interfaces
{
    public interface IUserService
    {

        Task<User> CreateUserAsync(string username, string password, string name);

        Task<User> FindUserAsync(string username, string password);

        Task<List<User>> GetUsersAsync();

        Task<UsersAccounts> AddUserAccountAsync(Guid userId, Guid accountId);
    }
}
