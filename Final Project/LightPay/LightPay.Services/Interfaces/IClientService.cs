using LightPay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightPay.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> RegisterClientAsync(string name);

        Task<List<Client>> GetClientsAsync();
    }
}
