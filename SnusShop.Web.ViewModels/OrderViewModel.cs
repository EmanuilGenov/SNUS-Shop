using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusShop.Web.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public bool IsCompleted { get; set; }
        public List<OrderProductViewModel> OrderProducts { get; set; } = new List<OrderProductViewModel>();
    }

}
