using e_organic.Data;
using e_organic.Data.Services;
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

        //Get: movies/detail/1
        public async Task<IActionResult> Details(int id)
        {
            var moviesDetails = await _service.GetProductByIdAsync(id);
            return View(moviesDetails);
        }
        public IActionResult Create()
        {
            /*ViewData["welcome"] = "Welcome to your e commerce website";
            ViewBag.Description = "this is description";*/
            return View();
        }
    }
}
