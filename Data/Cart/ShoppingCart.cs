using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace e_organic.Data.Cart
{
    public class ShoppingCart
    {
        public AddDbContext _context { get; set; }



        public String ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        public ShoppingCart(AddDbContext context)
        {
            _context = context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AddDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public void AddItemToCart(Product product)
        {
            var shoppingCartItem = _context.shoppingCartItems.FirstOrDefault(n => n.Product.id == product.id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null) {
                shoppingCartItem = new ShoppingCartItem() {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };  

                _context.shoppingCartItems.Add(shoppingCartItem);
            }
            else {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(Product movie)
        {
            var shoppingCartItem = _context.shoppingCartItems.FirstOrDefault(n => n.Product.id == movie.id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null) {
                if (shoppingCartItem.Amount > 1) {
                    shoppingCartItem.Amount--;
                }
                else {
                    _context.shoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        } 

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems = _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Product).ToList());
        }
        public double GetShoppingCartTotal()
        {
            var total = _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Product.price * n.Amount).Sum();
            return total;
        }

    }
}
