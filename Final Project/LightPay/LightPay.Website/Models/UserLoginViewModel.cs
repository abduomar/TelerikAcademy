using LightPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Website.Models
{
    public class UserLoginViewModel
    {

        public UserLoginViewModel()
        {
                
        }

        public UserLoginViewModel(User user)
        {
            this.Name = user.Name;
            this.Username = user.Username;
            this.Password = user.Password;
        }

        [MaxLength(35,ErrorMessage = "Name should only have max 35 symbols")]
        public string Name { get; set; }

        [Required]
        [MaxLength(16,ErrorMessage ="Invalid username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(32,ErrorMessage = "max symbols 32")]
        public string Password { get; set; }

    }
}
