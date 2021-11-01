using e_organic.Data.Base;
using e_organic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Data.Services
{
    public class ProductService:EntityBaseRepository<Product>, IProductService
    {
        public ProductService(ApplicationDbContext context):base(context) { }

    }
}
