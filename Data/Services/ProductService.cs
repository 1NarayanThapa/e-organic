using e_organic.Data.Base;
using e_organic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
    public class ProductService:EntityBaseRepository<NewProductVM>, IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<NewProductVM> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products.Include(v => v.Vendor).FirstOrDefaultAsync(n => n.Id == id);
            return productDetails;
        }
    }
}
