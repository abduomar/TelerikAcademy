using LightPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Website.Models
{
    public class AddUserAccountViewModel
    {

        public AddUserAccountViewModel()
        {

        }

        public AddUserAccountViewModel(UsersAccounts userAccount)
        {
            this.UserId = userAccount.UserId;
            this.AccountId = userAccount.AccountId;
            this.UserName = userAccount.User.Name;
            this.AccountName = userAccount.Account.Nickname;
        }
                     
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public Guid AccountId { get; set; }

        public string AccountName { get; set; }
    }
}
