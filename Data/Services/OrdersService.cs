using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Models;
using Microsoft.EntityFrameworkCore;

namespace e_organic.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AddDbContext _context;
        public OrdersService(AddDbContext context)

        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(String userId)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Product).Where(n => n.UserId == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, String userId, String userEmailAddress)
        {
            var order = new Order() {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items) {
                var orderItem = new OrderItem() {
                    Amount = item.Amount,
                    ProductId = item.Product.id,
                    OrderId = order.id,
                    Price = item.Product.price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync(); 
        }
    }
}
