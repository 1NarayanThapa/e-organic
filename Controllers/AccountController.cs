using e_organic.Data;
using e_organic.Data.ViewModels;
using e_organic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_organic.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _context = context; 
        } 
        public IActionResult Login() => View(new LoginVm());
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid) return View(loginVm);
            var user = await _userManager.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null) {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                if (passwordCheck) {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded) {
                        return RedirectToAction("Index", "Products");
                    }
                }
                TempData["Error"] = "Wrong Cerdintials. please Try Again";
                return View(loginVm);

            }
            TempData["Error"] = "Wrong Cerdintials. please Try Again";
            return View(loginVm);
        }


    }
}
