
using recipe.Models;
using recipe.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace recipe.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser customer= await userManager.FindByNameAsync(userVM.UserName);
                if(customer != null)
                {
                    bool Pass = await userManager.CheckPasswordAsync(customer,userVM.Password);
                    if (Pass)
                    {
                         await signInManager.SignInAsync(customer, userVM.RememberMe);
                        return RedirectToAction("Index", "recipe");
                   
                    }
                }
                ModelState.AddModelError("", "Username or Password are invalid ");
            }
            return View(userVM);
        }


        [HttpGet]
     public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser customer = new ApplicationUser();
                customer.UserName = userVM.UserName;
                customer.PasswordHash = userVM.Password;
                customer.PhoneNumber = userVM.PhoneNumber;
                customer.Email = userVM.Email;
                
                

                IdentityResult result= await userManager.CreateAsync(customer,userVM.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(customer, false);
             
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(userVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }



    }
}
