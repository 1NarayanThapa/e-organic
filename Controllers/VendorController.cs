using e_organic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Controllers
{
    public class VendorController : Controller
    {

        private readonly ApplicationDbContext _context;
        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {

           var data = await _context.Vendors.ToListAsync();
            return View(data);
        }
    }
}
