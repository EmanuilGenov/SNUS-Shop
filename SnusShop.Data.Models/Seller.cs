using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusShop.Data.Models
{
    public class Seller
    {
        public Seller() 
        {
            SellerProducts = new HashSet<SellerProduct>();
            Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }

        [Phone]
        [MaxLength(10)] // constant to add
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        public ICollection<SellerProduct> SellerProducts { get; set; }
    }
}
