using System.ComponentModel.DataAnnotations;

namespace Models.Administration
{
	public class EditRole
	{
		public EditRole()
		{
			Users = new List<string>();
		}

		public string Id { get; set; }

		[Required(ErrorMessage = "Role Name is required")]
		public string RoleName { get; set; }

		public List<string> Users { get; set; }
	}
}
