using LightPay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightPay.Services.DTOs.Clients
{
    public class ListClientDTO
    {
        public ICollection<Client> Clients { get; set; }
    }
}
