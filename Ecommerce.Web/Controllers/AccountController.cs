using Data.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;

namespace Ecommerce.Web.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountServices _services;
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountController(IAccountServices services, UserManager<ApplicationUser> userManager)
		{
			_services = services;
			_userManager = userManager;
		}

		public IActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Registration(Register model)
		{
			if (ModelState.IsValid)
			{
				var result = await _services.IsRegister(model);

				if (result.Equals(true))
				{
					return RedirectToAction("Login","Account");
				}
				ModelState.AddModelError(string.Empty, "Invalid Registration Attempt");
			}
			return View(model);
		}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(Login model)

		{
			if (ModelState.IsValid)
			{
				var result = await _services.IsLogin(model);
				if (result)
				{
					ViewBag.Loginmessage = "Login Successfully";
					return RedirectToAction("ListUsers","Account");
				}
				ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult ListUsers()
		{
			var users = _userManager.Users;
			return View(users);
		}
	}
}
