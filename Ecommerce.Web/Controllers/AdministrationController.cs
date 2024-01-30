using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Administration;
using Services.Interface;

namespace Ecommerce.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IAdministrationServices _adminService;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly UserManager<IdentityUser> _userManager;
        public AdministrationController(IAdministrationServices admin, RoleManager<IdentityRole> roleManager)
        {
            _adminService = admin;      
			_roleManager = roleManager;
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRole model)
        {

            if (ModelState.IsValid)
            {
                var result = await _adminService.CreateNewRole(model);

                if (result.Equals(true))
                {
                    return RedirectToAction("ListRoles", "Administration");
                }


            }

            return View(model);
        }

        public IActionResult ListRoles()
        {
            var roles = _adminService.GetRolesList();
            return View(roles);
        }

		[HttpGet]
		public async Task<IActionResult> EditRole(string id)
		{
			var result = await _adminService.GetEditRolesListByID(id);
			return View(result);
		}

		// This action responds to HttpPost and receives EditRoleViewModel
		[HttpPost]
		public async Task<IActionResult> EditRole(EditRole model)
		{
			var role = await _roleManager.FindByIdAsync(model.Id);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
				return View("NotFound");
			}
			else
			{
				role.Name = model.RoleName;

				// Update the Role using UpdateAsync
				var result = await _roleManager.UpdateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("ListRoles");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}

				return View(model);
			}

		}

		public async Task<IActionResult> DeleteRole(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
				return View("NotFound");
			}
			else
			{
				var result = await _roleManager.DeleteAsync(role);

				if (result.Succeeded)
				{

					return RedirectToAction("ListRoles");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}

				return View("ListRoles");
			}
		}
	}
}
