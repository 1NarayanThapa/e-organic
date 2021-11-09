using e_organic.Data;
using e_organic.Data.Static;
using e_organic.Data.ViewModels;
using e_organic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task <IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
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
                    if (result.Succeeded) 
                        {
                        return RedirectToAction("Index", "Products");
                    }
                }  
                TempData["Error"] = "Wrong Cerdintials. please Try Again1";
                return View(loginVm);

            }
            TempData["Error"] = "Wrong Cerdintials. please Try Againsa";
            return View(loginVm);
        }
        public IActionResult Register () => View(new RegisterVm());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid) return View(registerVm);
            var user = await _userManager.FindByEmailAsync(registerVm.EmailAddress);

            if(user != null) {
                TempData["Error"] = "This email address is already in use";
                return View(registerVm);
            }
            var newUser = new ApplicationUser() {
                FullName = registerVm.FullName,
                Email = registerVm.EmailAddress,
                UserName = registerVm.EmailAddress,


            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVm.Password);
            if (newUserResponse.Succeeded) {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                return View("RegisterCompleted");
            }

            TempData["Error"] = "passport not strong";
            return View(registerVm);


        }
        [HttpPost]
        public async Task  <IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Products"); 
        }
    }
}
 