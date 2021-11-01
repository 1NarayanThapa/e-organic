using e_organic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var allProducts = await _context.Products.Include(n=>n.Vendor).OrderBy(n=>n.Name).ToListAsync();
            return View(allProducts);
        }
    }
}
