using e_organic.Data;
using e_organic.Data.Services;
using e_organic.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            var allProducts = await _service.GetAllAsync(n =>n.Vendor);
            return View(allProducts);
        }
        //search method
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Vendor);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
       
            return View("Index", allProducts);
        }
        //Get: movies/detail/1
        public async Task<IActionResult> Details(int id)
        {
            var moviesDetails = await _service.GetProductByIdAsync(id);
            return View(moviesDetails);
        }

        //get:product/create
        public  async Task<IActionResult> Create()
        {
            var dropdownData = await _service.GetProductDropDownValue();
            ViewBag.Vendors = new SelectList(dropdownData.Vendors, "Id", "Name");
            return View();
        }
        //post:product/create/
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid) {
                var dropdownData = await _service.GetProductDropDownValue();
                ViewBag.Vendors = new SelectList(dropdownData.Vendors, "Id", "Name");

                return View(product);
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index)) ;
        }

        //get:product/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var moviesDetails = await _service.GetProductByIdAsync(id);
            if (moviesDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = moviesDetails.Id,
                Name = moviesDetails.Name,
                Description = moviesDetails.Description,
                ImageUrl = moviesDetails.ImageUrl,
                Price=moviesDetails.Price,
                ProductCatagory=moviesDetails.ProductCatagory,
                VendorId=moviesDetails.VendorId,
            };
            var dropdownData = await _service.GetProductDropDownValue();
            ViewBag.Vendors = new SelectList(dropdownData.Vendors, "Id", "Name");
            return View(response);
        }
        //post:product/edit/
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {

            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var dropdownData = await _service.GetProductDropDownValue();
                ViewBag.Vendors = new SelectList(dropdownData.Vendors, "Id", "Name");

                return View(product);
            }
            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }



    }
}
