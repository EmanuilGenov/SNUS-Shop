using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusShop.Data.Models
{
    public class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
            Id = new Guid();
        }
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
        public ICollection<Order> Orders { get; set; }
    }
}
