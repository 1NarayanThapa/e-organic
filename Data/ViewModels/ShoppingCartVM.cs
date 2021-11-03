using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Data.Cart;

namespace e_organic.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public Double ShoppingCartTotal { get; set; }
    }
}
