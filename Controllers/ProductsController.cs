using e_organic.Data;
using e_organic.Data.Services;
using e_organic.Data.ViewModels;
using e_organic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
            public ProductsController(IProductsService service)
        {
            _service = service;


        }
        public async Task<IActionResult> Index()
        {
            var allProduct = await _service.GetAllAsync(n=>n.Vendor );  
      
            return View(allProduct);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProduct = await _service.GetAllAsync(n => n.Vendor);

            if (!string.IsNullOrEmpty(searchString)) {
                var filteredResult = allProduct.Where(n => n.name.Contains(searchString) || n.Discription.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allProduct); 
        }
        //GEt:Product/Details/1
        public async Task<IActionResult>Details(int id)
        {

            var ProductDetail = await _service.GetProductByIdAsync(id);
            return View(ProductDetail);
        }

        //cretae/Product
        public async Task<IActionResult> Create()
        {

            var VendorDropdowndata = await _service.GetNewProductDropdownValues();

            ViewBag.Vendors = new SelectList(VendorDropdowndata.Vendors, "id", "name");
            return View();

        }
        //adding product data to the database
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid) {

                var VendorDropdowndata = await _service.GetNewProductDropdownValues();


                ViewBag.Vendors = new SelectList(VendorDropdowndata.Vendors, "id", "name");
                return View(product);
            }
            await _service.addNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        //cretae/Product/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("not found");

            var response = new NewProductVM() {
                id = ProductDetails.id,
                name = ProductDetails.name,
                Discription = ProductDetails.Discription,
                price = ProductDetails.price,
                ProductCategory = ProductDetails.ProductCategory,
                imageUrl = ProductDetails.imageUrl,
                VendorId = ProductDetails.VendorId
            };

            var VendorDropdowndata = await _service.GetNewProductDropdownValues();

            ViewBag.Vendors = new SelectList(VendorDropdowndata.Vendors, "id", "name");
            return View(response);

        }
        //adding product data to the database
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewProductVM product)
        {
            if (id != product.id) return View("not found");
            if (!ModelState.IsValid) {

                var VendorDropdowndata = await _service.GetNewProductDropdownValues();


                ViewBag.Vendors = new SelectList(VendorDropdowndata.Vendors, "id", "name");
                return View(product);
            }
            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
