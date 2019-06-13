using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrinkStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var res = await userManager.CreateAsync(user, model.Password);
                if (res.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("list", "drink");
                }
 
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (res.Succeeded)
                {
                    return RedirectToAction("list", "drink");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }
        public IActionResult logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("list", "drink");
        }

    }
}