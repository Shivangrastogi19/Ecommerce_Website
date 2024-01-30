using Microsoft.AspNetCore.Identity;
using Models.Administration;

namespace Services.Interface
{
    public interface IAdministrationServices
    {
        Task<bool> CreateNewRole(CreateRole model);
        IEnumerable<IdentityRole> GetRolesList();
		Task<EditRole> GetEditRolesListByID(string id);
		Task<bool> UpdateRole(EditRole model);
	}
}
