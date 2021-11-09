using e_organic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
   public interface IOrdersService
    {

        //get data from database cart items
        Task StoreOrderAsync(List<ShoppingCartItem> items, String userId, string userEmailAddress);

        //post data to database  cart items
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);

    }
}
