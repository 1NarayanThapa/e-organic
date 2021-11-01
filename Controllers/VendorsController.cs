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
        public async Task<IActionResult> Create([Bind("ImageUrl,name,Discription")] Vendor vendor)
        {

            if (!ModelState.IsValid) return View(vendor);
            await _service.AddAsync(vendor);
            return RedirectToAction(nameof(Index));
        }

        //Get:Vendors:Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var VendorDetails = await _service.GetByIdAsync(id);
                if (VendorDetails == null) return View("Not Found");
            return View(VendorDetails);

        }
        //Get:Vendor/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var VendorDetails = await _service.GetByIdAsync(id);
            if (VendorDetails == null) return View("Not Found");
            return View(VendorDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("id,ImageUrl,name,Discription")] Vendor vendor)
        {

            if (!ModelState.IsValid) return View(vendor);
            await _service.UpdateAsync(id,vendor);
            return RedirectToAction(nameof(Index));
        }
        //Get:Vendor/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var VendorDetails = await _service.GetByIdAsync(id);
            if (VendorDetails == null) return View("Not Found");
            return View(VendorDetails);

        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var VendorDetails = await _service.GetByIdAsync(id);
            if (VendorDetails == null) return View("Not Found");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
