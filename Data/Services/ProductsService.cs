using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_organic.Data.Base;
using e_organic.Data.ViewModels;
using e_organic.Models;
using Microsoft.EntityFrameworkCore;

namespace e_organic.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AddDbContext _context;
        public ProductsService(AddDbContext context) : base(context)
        {

            _context = context;
        }



        public async Task<Product> GetProductByIdAsync(int id)
        {
            var ProductDetails = await _context.Products
                .Include(c => c.Vendor)
                 .FirstOrDefaultAsync(n => n.id == id);
            return ProductDetails;
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownValues()
        {
            var response = new NewProductDropdownsVM() {
                Vendors = await _context.Vendors.OrderBy(n => n.name).ToListAsync()
            };
            return response;
        }
    }
}

