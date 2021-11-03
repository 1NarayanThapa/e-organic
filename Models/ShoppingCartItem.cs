using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }

        public String ShoppingCartId { get; set; }
    }
}
