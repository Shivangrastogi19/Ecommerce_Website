using Data.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Models.Administration;
using Services.Interface;

namespace Services.Implementation
{
    public class AdministrationServices : IAdministrationServices
    {
        private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<ApplicationUser> _userManager;
        public AdministrationServices(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
			_userManager = userManager;

		}

        public async Task<bool> CreateNewRole(CreateRole model)
        {
            // We just need to specify a unique role name to create a new role
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };

            // Saves the role in the underlying AspNetRoles table
            IdentityResult result = await _roleManager.CreateAsync(identityRole);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<IdentityRole> GetRolesList()
        {
            var roles = _roleManager.Roles;
            return roles;
        }

		public async Task<EditRole> GetEditRolesListByID(string id)
		{
			// Find the role by Role ID
			var role = await _roleManager.FindByIdAsync(id);


			var model = new EditRole
			{
				Id = role.Id,
				RoleName = role.Name
			};

			// Retrieve all the Users
			foreach (var user in _userManager.Users)
			{
				// If the user is in this role, add the username to
				// Users property of EditRoleViewModel. This model
				// object is then passed to the view for display
				if (await _userManager.IsInRoleAsync(user, role.Name))
				{
					model.Users.Add(user.UserName);
				}
			}

			return model;
		}

		public async Task<bool> UpdateRole(EditRole model)
		{

			IdentityRole identityRole = new IdentityRole { Name = model.RoleName };
			// Updating the Role using UpdateAsync
			var result = await _roleManager.UpdateAsync(identityRole);

			if (result.Succeeded)
			{
				return true;

			}

			return false;
		}
	}
}
