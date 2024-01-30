using Data.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Models;
using Services.Interface;

namespace Services.Implementation
{
	public class AccountServices: IAccountServices
	{

		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;

		public AccountServices(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			_roleManager = roleManager;

		}

		public async Task<bool> IsRegister(Register model)
		{
			var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber , FName = model.FName,LName = model.LName, Address = model.Address};
			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, isPersistent: false);
				return true;
			}

			return false;
		}

		public async Task<bool> IsLogin(Login model)
		{
			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,true, false);
			if (result.Succeeded)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
