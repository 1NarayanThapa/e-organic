using e_organic.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart{get;set;}

        public double ShoppingCartTotal  { get; set;   }
    }
}
