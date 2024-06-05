using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusShop.Data.Models
{
    public class SellerProduct
    {
        [Required]
        [ForeignKey(nameof(Seller))]
        public Guid SellerId { get; set; }
        [Required]
        public Seller Seller { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; } = null!;

    }
}
