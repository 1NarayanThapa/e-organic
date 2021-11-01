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
        //GEt:Product/Details/1
        public async Task<IActionResult>Details(int id)
        {

            var ProductDetail = await _service.GetProductByIdAsync(id);
            return View(ProductDetail);
        }
    }
}
