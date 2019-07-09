using System;
using System.Collections.Generic;
using System.Text;

namespace LightPay.Models
{
    public class UsersAccounts
    {
        public Guid AccountId { get; set; }

        public Guid UserId { get; set; }

        public Account Account { get; set; }

        public User User { get; set; }
    }
}
