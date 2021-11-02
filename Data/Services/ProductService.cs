using e_organic.Data.Base;
using e_organic.Data.ViewModels;
using e_organic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync
            (NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                ImageUrl = data.ImageUrl,
                Price = data.Price,
                ProductCatagory = data.ProductCatagory,
                VendorId = data.VendorId,
            };
            await _context.AddAsync(newProduct);
            await _context.SaveChangesAsync();

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products.Include(v => v.Vendor).FirstOrDefaultAsync(n => n.Id == id);
            return productDetails;
        }

        public async Task<NewProductDropDownVM> GetProductDropDownValue()
        {
            var response = new NewProductDropDownVM()
            {
                Vendors = await _context.Vendors.OrderBy(n => n.Name).ToListAsync(),
        };
        return response;
    }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbProduct != null)
            {

                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.ImageUrl = data.ImageUrl;
                dbProduct.Price = data.Price;
                dbProduct.ProductCatagory = data.ProductCatagory;
                dbProduct.VendorId = data.VendorId;

                await _context.SaveChangesAsync();
            };


         
               //await _context.SaveChangesAsync();
        }

        
    }
}

