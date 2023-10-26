using Blog.Entity.Entities;
using Blog.Entity.ViewModels.Articles;
using Blog.Entity.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(ViewUserLogin viewUserLogin)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(viewUserLogin.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, viewUserLogin.Password, viewUserLogin.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new {Area = "Admin"});
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-Posta adresiniz veya şifreniz yanlış.");
                        return View(); 
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-Posta adresiniz veya şifreniz yanlış.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}
