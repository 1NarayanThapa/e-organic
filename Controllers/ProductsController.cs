using e_organic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AddDbContext _context;
            public ProductsController(AddDbContext context)
        {
            _context = context;


        }
        public async Task<IActionResult> Index()
        {
            var allProduct = await _context.Products.ToListAsync();
      
            return View(allProduct);
        }
    }
}
