using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_organic.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }*/
             
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        //Orderes Related Tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> shoppingCartItems { get; set; }

    }
    
}
