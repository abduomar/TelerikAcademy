using LightPay.Data.Context;
using LightPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LightPay.Website.Services.Test
{

    public static class TestUtils
    {
        public static DbContextOptions GetOptions(string databaseName)
        {
            var serviceCollection = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            return new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static LightPayContext PopulateContextWithClientParams(string databaseName)
        {
            var options = GetOptions(databaseName);
            var context = new LightPayContext(options);

            context.Clients.Add(new Client() { Name = "Telerik"});
            context.Clients.Add(new Client() { Name = "Dior" });

            context.SaveChanges();

            return context;
        }

        public static LightPayContext PopulateContextWithAccountParams(string databaseName)
        {
            var options = GetOptions(databaseName);

            var context = new LightPayContext(options);

            var client = new Client() { Name = "Hrisi" };
            context.Clients.AddAsync(client);
                        
            context.Accounts.Add(new Account() { AccountNumber = "1234567890", Nickname = "1234567890", Balance = 3000000, ClientId = client.Id, CreatedOn = DateTime.Now });
            context.Accounts.Add(new Account() { AccountNumber = "1245373456", Nickname = "1245373456", Balance = 150000, ClientId = client.Id, CreatedOn = DateTime.Now });
            context.Accounts.Add(new Account() { AccountNumber = "1999999456", Nickname = "1999999456", Balance = 70000, ClientId = client.Id, CreatedOn = DateTime.Now });

            context.SaveChanges();

            return context;
        }

        public static LightPayContext PopulateContextWithAdmin(string databaseName)
        {
            var options = GetOptions(databaseName);
            var context = new LightPayContext(options);
            
            context.Administrators.AddAsync(new Administrator { Username = "John", Password = "John567@" });

            context.SaveChanges();

            return context;
        }

        public static LightPayContext PopulateContextWithUsers(string databaseName)
        {
            var options = GetOptions(databaseName);
            var context = new LightPayContext(options);

            context.Users.Add(new User() { Name = "Mickael", Username = "Mike", Password = "Mike246@"});
            context.Users.Add(new User() { Name = "Jack", Username = "J", Password = "Jack246@" });

            context.SaveChanges();

            return context;
        }
    }
}
