using _4Desk_OHD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _4Desk_OHD.Controllers
{
	public class AccountsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountsController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel input)
		{
			if (ModelState.IsValid)
			{
                var result = await _signInManager.PasswordSignInAsync(input.UserName, input.Password, true, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
					ModelState.AddModelError("Password", "UserName or Password is incorrect");
                    return View();
                }
            }
			return View();
		}

		public async Task<IActionResult> Logout()
		{
            await _signInManager.SignOutAsync();
			return Redirect("/");
        }
	}
}
