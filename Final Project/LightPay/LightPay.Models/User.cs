using System;
using System.Collections.Generic;

namespace LightPay.Models
{

    public class User : BaseClass

    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<UsersAccounts> UsersAccounts { get; set; }

    }
}
