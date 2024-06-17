using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusShop.Data.Models
{
    public class Product
    {

        [Key]
        public int Id { get; init; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public ICollection<SellerProduct> ProductSellers = new HashSet<SellerProduct>();
        public ICollection<OrderProduct> ProductOrders = new HashSet<OrderProduct>();
    }
}
