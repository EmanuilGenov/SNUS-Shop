using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusShop.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; } = null!;
        public Client Client { get; set; } = null!;

        public bool IsCompleted { get; set; }

        [Required]
        public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
