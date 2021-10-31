using e_organic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Controllers
{
    public class VendorsController : Controller
    {
        private readonly AddDbContext _context;
        public VendorsController(AddDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var VendorsData = await _context.Vendors.ToListAsync();
            return View(VendorsData);
        }
    }
}
