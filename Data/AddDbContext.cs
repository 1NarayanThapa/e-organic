using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Models;
using Microsoft.EntityFrameworkCore;

namespace e_organic.Data
{
    public class AddDbContext:DbContext

    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options)
        {
        }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }*/
             
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    
}
