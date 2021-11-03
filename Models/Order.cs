using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public String email { get; set; }
        public String UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
