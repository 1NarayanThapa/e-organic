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
    public class VendorController : Controller
    {

        private readonly IVendorService _service;
        public VendorController(IVendorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            var vendorData = await _service.GetAllAsync();
            return View(vendorData);
        }

        //method to create new vendor
        //get method Vendor/Create
        
        public IActionResult Create()
        {
            return View();
        }
        //post method
        [HttpPost]
        public async Task<IActionResult>Create([Bind("Name,ImageUrl,Description,Address")]Vendor newVendor)
        {
            if (!ModelState.IsValid)
            {
                return View(newVendor);
            }
          await  _service.AddAsync(newVendor);
            return RedirectToAction(nameof(Index));
        }


        //get deatil function
        public async Task<IActionResult>Details(int id)
        {
            var vendorDetails = await _service.GetByIdAsync(id);
            if (vendorDetails == null) return View("NotFound");
            return View(vendorDetails);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var vendorDetails = await _service.GetByIdAsync(id);
            if (vendorDetails == null) return View("NotFound");
            return View(vendorDetails);
        }
        //post method
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("VendorId,Name,ImageUrl,Description,Address")] Vendor newVendor)
        {
            if (!ModelState.IsValid)
            {
                return View(newVendor);
            }
            await _service.UpdateAsync(id, newVendor);
            return RedirectToAction(nameof(Index));
        }

    }
}
