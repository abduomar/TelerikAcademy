using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightPay.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly LightPayContext context;

        public ClientService(LightPayContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
               
        public async Task<Client> RegisterClientAsync(string name)
        {
            var clientName = await this.context.Clients
                .FirstOrDefaultAsync(cl => cl.Name == name);

            if (clientName != null)
            {
                throw new ArgumentException("This name already exist");
            }

            var client = new Client()
            {
                Name = name,
                CreatedOn = DateTime.Now
            };

            await this.context.Clients.AddAsync(client);
            await this.context.SaveChangesAsync();
            return client;
        }

        public async Task<List<Client>> GetClientsAsync()
        {
           return await this.context.Clients
                .Include(cl => cl.Accounts)
                .ToListAsync();
        }
    }
}
