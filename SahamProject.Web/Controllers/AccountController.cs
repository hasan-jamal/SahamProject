using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SahamProject.Web.Models;
using SahamProject.Web.Utlity;
using SahamProject.Web.ViewModels;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace SahamProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SahamProjectContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SahamProjectContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users() => View(await _context.Users.ToListAsync());


        public IActionResult Index() => View(new LoginVM());

        //POST: Acount/Login
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) { TempData["Error"] = "Wrong credentials. please try again!"; return View(login); }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);
            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Wrong credentials. please try again!";
            return View(login);

        }

        public IActionResult Register() => View(new RegisterVM());

        //POST: Acount/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null) { TempData["Error"] = "The Email Address Already Exist"; return View(registerVM); }
            var newuser = new ApplicationUser()
            {
                Name = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
            };
            var result = await _userManager.CreateAsync(newuser, registerVM.Password);
            if (!result.Succeeded)
                return View(registerVM);

            await _userManager.AddToRoleAsync(newuser, SD.Role_Customer);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
