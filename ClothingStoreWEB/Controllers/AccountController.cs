using ClothingStoreWEB.Context;
using ClothingStoreWEB.Models;
using ClothingStoreWEB.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace ClothingStoreWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (_userManager.Users.Where(a => a.Email == model.Email).Count() > 0)
            {
                ModelState.AddModelError("", "This email address is already registered, try logging in with this email address or enter a different one when registering.");
            }
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FName = model.FName,
                    LName = model.LName,
                    EmailConfirmed = false
                };
                var result = await _userManager.CreateAsync(user, model.Password); // закидаємо користувача до бд-шки
                if (result.Succeeded)
                {
                    // установка кукі
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // перевіряємо, чи належить URL додатку
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login and/or password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // видаляємо аутентифікаційні куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
