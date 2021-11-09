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
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        //get login
        public IActionResult Login()
        {
            var response = new LoginVm();
            return View(response);
        }

        //post login
        [HttpPost]

        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid) return View(loginVm);
            var user = await _userManager.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                }
                TempData["Error"] = "Wrong Credential, try again";
                return
                    View(loginVm);
            }
            TempData["Error"] = "Wrong Credential, try again";
            return
                View(loginVm);
        }

        //Get registewr

        public IActionResult Register()
        {
            var response = new RegisterVm();
            return View(response);
        }


        //post register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVM)
        {

            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Email address already use";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                Name = registerVM.Name,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,

            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
            //Console.WriteLine(newUserResponse);
            if (newUserResponse.Succeeded == true)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("RegisterCompleted");
            }
            TempData["Error"] = "passwor is not strong *required nonalphanumeric lower and Uppercase letter ";
            return View(registerVM);



        }
        //method for logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Product");
        }

        //method for listing the users
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
    
    }
}
