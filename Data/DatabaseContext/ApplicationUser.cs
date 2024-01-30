using Microsoft.AspNetCore.Identity;

namespace Data.DatabaseContext
{
	public class ApplicationUser: IdentityUser
	{
        public string FName { get; set; }
		public string LName { get; set; }
		public string Address {  get; set; }
    }
}
