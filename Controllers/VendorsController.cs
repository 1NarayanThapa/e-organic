using e_organic.Data;
using e_organic.Data.Services;
using e_organic.Models;
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
        private readonly IVendorsService _service;
        public VendorsController(IVendorsService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var VendorsData = await _service.GetAllAsync();
            return View(VendorsData);
        }

        //Getdata/Vendors/Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageUrl,name,Discription,Address")] Vendor vendor)
        {

            if (!ModelState.IsValid) return View(vendor);
            await _service.AddAsync(vendor);
            return RedirectToAction(nameof(Index));
        }

    }
}
