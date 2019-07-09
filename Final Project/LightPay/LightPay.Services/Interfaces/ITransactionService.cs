using LightPay.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightPay.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> MakePayment(string senderAccountName, decimal amount,
            string recieverAccountName, string description,bool isSaved);

        Task<ICollection<Transaction>> GetAccountTransactions(string accountNickname);

        Task<ICollection<Transaction>> GetTransactions();
    }
}
