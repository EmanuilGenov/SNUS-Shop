using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusShop.Data.Models
{
    public class Client : IdentityUser
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
