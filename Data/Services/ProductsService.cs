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

        public async Task addNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product() {
                name = data.name,
                Discription = data.Discription,
                imageUrl = data.imageUrl,
                VendorId = data.VendorId,
                ProductCategory = data.ProductCategory,
                price=data.price,


            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {

            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.id == data.id);
            if (dbProduct != null) {

                dbProduct.name = data.name;
                    dbProduct.Discription = data.Discription;
                dbProduct.imageUrl = data.imageUrl;
                dbProduct.VendorId = data.VendorId;
                dbProduct.ProductCategory = data.ProductCategory;
                dbProduct.price = data.price;
              
             await _context.SaveChangesAsync();


            };
                

            }
           
        }
    }


