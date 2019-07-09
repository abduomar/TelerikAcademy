using LightPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Website.Models
{
    public class ListTransactionViewModel
    {
        public ListTransactionViewModel()
        {

        }

        public ListTransactionViewModel(Transaction transaction)
        {
            this.SenderAccountNumber = transaction.SenderAccount.AccountNumber;
            this.RecieverAccountNumber = transaction.RecieverAccount.AccountNumber;

            this.PayerClient = transaction.SenderAccount.Client.Name;
            this.PayeeClient = transaction.RecieverAccount.Client.Name;

            this.Description = transaction.Description;
            this.Ammount = transaction.Ammount;
            this.CreatedOn = DateTime.Now;

            this.SenderAccount = transaction.SenderAccount;
            this.RecieverAccount = transaction.RecieverAccount;

            this.IsSaved = transaction.IsSaved;

        }

        public string SenderAccountNumber { get; set; }

        public string RecieverAccountNumber { get; set; }

        public string PayerClient { get; set; }

        public string PayeeClient { get; set; }

        public string Description { get; set; }

        public decimal Ammount { get; set; }

        public DateTime CreatedOn { get; set; }

        public Account SenderAccount { get; set; }

        public Account RecieverAccount { get; set; }

        public bool IsSaved { get; set; }

        public string SenderAccountUsername { get; set; }

        public string RecieverAccountUsername { get; set; }
    }
}
