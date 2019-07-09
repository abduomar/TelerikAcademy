using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Services.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly LightPayContext context;

        public TransactionService(LightPayContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

     

        public async Task<Transaction> MakePayment(string senderAccountName, decimal amount,
            string recieverAccountName, string description, bool isSaved)
        {
            var payment = new Transaction();

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    var senderAccount = await this.context.Accounts
                        .SingleOrDefaultAsync(t => t.Nickname == senderAccountName);

                    var recieverAccount = await this.context.Accounts
                        .SingleOrDefaultAsync(t => t.Nickname == recieverAccountName);

                    if (senderAccount == null)
                    {
                        throw new ArgumentException("Account with this name does not exist");
                    }

                    if (recieverAccount == null)
                    {
                        throw new ArgumentException("Account with this name does not exist");
                    }

                    if (amount <= 0)
                    {
                        throw new ArgumentException("Transfer amount must be positive number");
                    }

                    if (senderAccount.Balance < amount)
                    {
                        throw new ArgumentException("Insufficient funds");
                    }

                    payment = new Transaction()
                    {
                        SenderAccount = senderAccount,
                        RecieverAccount = recieverAccount,
                        Ammount = amount,
                        Description = description,
                        CreatedOn = DateTime.Now,
                        //IsSaved = isSaved;
                    };

                    if (!isSaved)
                    {
                        senderAccount.Balance -= amount;
                        recieverAccount.Balance += amount;
                        await this.context.Transactions.AddAsync(payment);
                        await this.context.SaveChangesAsync();

                        senderAccount.OutgoingTransactions.Add(payment);
                        recieverAccount.IncomingTransactions.Add(payment);
                    }

                    transaction.Commit();                    
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

                return payment;

            }
        }

        public async Task<ICollection<Transaction>> GetAccountTransactions(string accountNickname)
        {
            var account = await this.context.Accounts
                .Include(a => a.IncomingTransactions)
                .Include(a => a.OutgoingTransactions)
                .FirstOrDefaultAsync(a => a.Nickname == accountNickname);

            return await this.context.Transactions
                .Include(t => t.SenderAccount)
                .Include(t => t.RecieverAccount)
                .Where(t => t.SenderAccount == account || t.RecieverAccount == account)
                .ToListAsync();



        }

        public async Task<ICollection<Transaction>> GetTransactions()
        {

            return await this.context.Transactions
                .Include(t => t.SenderAccount)
                .Include(t => t.RecieverAccount)
                .ToListAsync();



        }


    }
}
